using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Primary.SchoolApp.DTO;
using Primary.SchoolApp.Extensions;
using SchoolManagement.Application;
using SchoolManagement.Application.Extensions;
using SchoolManagement.Core.Enum;
using SchoolManagement.Core.Model;
using SchoolManagement.Helper;
using SchoolManagement.UI.Localization;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Primary.SchoolApp.UI
{
    internal class EditStudentEnrollingForm : SchoolManagement.UI.EditStudentEnrollingForm
    {

        private readonly ILogService logService;
        private readonly IStudentService studentService;
        private readonly ISchoolClassService classService;
        private readonly ISchoolRoomService roomService;
        private readonly IStudentEnrollingService studentEnrollingService;
        private readonly ILogger<EditStudentEnrollingForm> logger;
        private readonly ClientApp clientApp;
        private StudentEnrolling selectedEnrolling;
        private StudentRoom oldStudentRoom;
        public EditStudentEnrollingForm(ILogService logService, IStudentService studentService, ISchoolClassService classService,
             ISchoolRoomService roomService, ClientApp clientApp, IStudentEnrollingService studentEnrollingService, ILogger<EditStudentEnrollingForm> logger)
        {
            this.logService = logService;
            this.studentService = studentService;
            this.classService = classService;
            this.roomService = roomService;
            this.studentEnrollingService = studentEnrollingService;
            this.clientApp = clientApp;
            this.logger = logger;
            ClassDropDownList.DataSource = Program.SchoolClassList;
            ClassDropDownList.SelectedIndex = -1;
            InitEvents();
        }


        private void InitEvents()
        {
            SaveButton.Click += SaveButton_Click;
            this.Shown += OnShown;
            AddStudentButton.Click += AddStudentButton_Click;
            AddClassButton.Click += AddClassButton_Click;
            AddRoomButton.Click += AddRoomButton_Click;
            ClassDropDownList.SelectedValueChanged += ClassDropDownList_SelectedValueChanged;
        }

        internal void Init(StudentEnrolling enrolling)
        {

            if (enrolling != null)
            {
                selectedEnrolling = enrolling;
                var item = new RadListDataItem
                {
                    Text = $"{enrolling.Student.LastName} {enrolling.Student.FirstName} | {enrolling.Student.IdNumber}",
                    Value = enrolling.Student.Id,
                    Image = File.Exists(enrolling.Student.PictureUrl) ? new Bitmap(Image.FromFile(enrolling.Student.PictureUrl), new Size(32, 32)) : new Bitmap(Helper.GetImage(Resources.no_image), new Size(32, 32)),
                    Tag = enrolling.Student
                };

                StudentDropDownList.Items.Add(item);
                StudentDropDownList.ShowDropDown();
                StudentDropDownList.SelectedValue = enrolling.StudentId;
                StudentDropDownList.ReadOnly = true;
                OldSchoolTextBox.Text = enrolling.OldSchool;
                RepeaterDropDownList.SelectedValue = enrolling.IsRepeater == true ? 1 : 0;
                ClassDropDownList.SelectedValue = enrolling.ClassId;
                LoadStudentRoom(enrolling.StudentId, enrolling.SchoolYearId);
                EnrollingDateTimePicker.Value = enrolling.Date;
            }
            CheckPermissions();
        }

        private async void LoadStudentRoom(int studentId, int schoolYearId)
        {
            var studentRoom = await studentEnrollingService.GetStudentRoomAsync(studentId, schoolYearId);
            if (studentRoom != null)
            {
                RoomDropDownList.SelectedValue = studentRoom.RoomId;
                oldStudentRoom = studentRoom;
            }
            else
            {
                StudentDropDownList.SelectedValue = null;
            }
        }

        private void OnShown(object sender, EventArgs e)
        {
            EnrollingDateTimePicker.Focus();

        }
        private void ClassDropDownList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ClassDropDownList.SelectedItem?.DataBoundItem is SchoolClass selectedRecord)
            {
                ClassDropDownList.RootElement.ToolTipText = selectedRecord.Name;
                RoomDropDownList.DataSource = Program.SchoolRoomList.Where(x => x.ClassId == selectedRecord.Id);
                var payments = GetInitialPaymentList(selectedRecord.Id);
                var amountToPaid = payments.Sum(x => x.Balance);
                // ajout total des frais scolarité
                string totalText = Language.labelTuitionFees;
                if (Thread.CurrentThread.CurrentUICulture.Name != "en-GB")
                {
                    totalText = $"{totalText}: {amountToPaid} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol} ( {amountToPaid.ToLetter(CountryLanguage.French)}) ";
                }
                else
                {
                    totalText = $"{totalText}: {amountToPaid} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol} ( {amountToPaid.ToLetter(CountryLanguage.English)}) ";
                }
                FeesTotalLabel.Text = totalText;
            }
        }
        private void AddRoomButton_Click(object sender, EventArgs e)
        {
            if (RoomDropDownList.SelectedItem != null)
            {
                if (RoomDropDownList.SelectedItem.DataBoundItem is SchoolRoom record)
                {
                    ShowSchoolRoomEditForm(record);
                }
            }
            else
            {
                ShowSchoolRoomAddForm();
            }
        }
        private void AddClassButton_Click(object sender, EventArgs e)
        {
            if (ClassDropDownList.SelectedItem != null)
            {
                if (ClassDropDownList.SelectedItem.DataBoundItem is SchoolClass record)
                {
                    ShowSchoolClassEditForm(record);
                }
            }
            else
            {
                ShowSchoolClassAddForm();
            }
        }
        private void AddStudentButton_Click(object sender, EventArgs e)
        {
            if (StudentDropDownList.SelectedItem != null)
            {
                if (StudentDropDownList.SelectedItem.Tag is Student student)
                {
                    ShowStudentEditForm(student);
                }
            }
            else
            {
                ShowStudentAddForm();
            }
        }
        private async void SaveButton_Click(object sender, EventArgs e)
        {
           
            if (IsValidData())
            {
                this.SaveButton.Enabled = false;
                var selectedClass = ClassDropDownList.SelectedItem.DataBoundItem as SchoolClass;
                if (selectedClass.Id != selectedEnrolling.ClassId)
                {
                    var oldTuitionAmount = GetInitialPaymentList(selectedEnrolling.ClassId).Sum(x => x.Balance);
                    var currentTuitionAmount = GetInitialPaymentList(selectedClass.Id).Sum(x => x.Balance);
                    if (oldTuitionAmount != currentTuitionAmount)
                    {
                    }
                    string message = $"Les frais de scolarité pour la classe sélectionnée ({selectedClass.Name}: {oldTuitionAmount}) ne correspondent pas à ceux de la classe précédente ({selectedEnrolling?.SchoolClass?.Name}: {currentTuitionAmount}).\r\n Voulez-vous continuer ?";
                    if (Thread.CurrentThread.CurrentUICulture.Name == "en-GB")
                    {
                        message = $"The tuition fees for the selected class ({selectedClass.Name}: {oldTuitionAmount}) do not match those of the previous class ({selectedEnrolling?.SchoolClass?.Name}: {currentTuitionAmount}).\r\n Do you want to continue?";
                    }
                    DialogResult dialogResult = RadMessageBox.Show(message, "", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                    if (dialogResult == DialogResult.No)
                    {
                        this.SaveButton.Enabled = true;
                        return;
                    }
                }
                var selectedRoom = RoomDropDownList.SelectedItem.DataBoundItem as SchoolRoom;
                var selectedStudent = selectedEnrolling.Student;
               
                selectedEnrolling.Date = EnrollingDateTimePicker.Value;
                selectedEnrolling.StudentId = selectedStudent.Id;
                selectedEnrolling.ClassId = selectedClass.Id;
                selectedEnrolling.SchoolClass = selectedClass;
                selectedEnrolling.IsRepeater = (int)RepeaterDropDownList.SelectedValue != 0;
                selectedEnrolling.OldSchool = OldSchoolTextBox.Text;
                //Mise à jour de l'inscription
                var updateEnrollingIsDone = await studentEnrollingService.UpdateStudentEnrollingAsync(selectedEnrolling);
                if (updateEnrollingIsDone)
                {
                    //enregistrement du log
                    Log logEnrol = new()
                    {
                        UserAction = $"Mise à jour de l'inscription de l'élève {selectedEnrolling.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                        UserId = clientApp.UserConnected.Id
                    };
                     await logService.CreateLog(logEnrol);
                    logger.LogInformation("Mise à jour de l'inscription de l'élève {StudentFullName} par l'utilisateur {UserName} sur le poste {IpAddress}",
                                          selectedEnrolling.Student.FullName,
                                          clientApp.UserConnected.UserName,
                                          clientApp.IpAddress
                    );
                    if(oldStudentRoom != null && oldStudentRoom.RoomId != selectedRoom.Id)
                    {
                        //suppression de l'ancienne salle
                        var deleteOldRoomIsDone = await studentEnrollingService.DeleteStudentRoomAsync(selectedEnrolling.StudentId, selectedEnrolling.SchoolYearId);
                        if (deleteOldRoomIsDone)
                        {
                            Log logOldRoom = new()
                            {
                                UserAction = $"Suppression de l'affectation de la salle {oldStudentRoom.Room.Name} à l'élève {oldStudentRoom.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                                UserId = clientApp.UserConnected.Id
                            };
                            await logService.CreateLog(logOldRoom);
                            logger.LogInformation("Suppression de l'affectation de la salle {RoomName} à l'élève {StudentFullName} par l'utilisateur {UserName} sur le poste {IpAddress}",
                                                  oldStudentRoom.Room.Name,
                                                  oldStudentRoom.Student.FullName,
                                                  clientApp.UserConnected.UserName,
                                                  clientApp.IpAddress
                            );
                        }
                        //affectation d'une salle de classe
                        var studentRoom = new StudentRoom()
                        {
                            Room = selectedRoom,
                            RoomId = selectedRoom.Id,
                            StudentId = selectedStudent.Id,
                            Student = selectedStudent,
                            SchoolYearId = selectedEnrolling.SchoolYearId,
                            Note = Language.labelRegistration
                        };
                        var createStudentRoomIsDone = await studentEnrollingService.CreateStudentRoomAsync(studentRoom);
                        if (createStudentRoomIsDone)
                        {
                            Log logRoom = new()
                            {
                                UserAction = $"Affectation de la salle {studentRoom.Room.Name} à l'élève {studentRoom.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                                UserId = clientApp.UserConnected.Id
                            };
                            await   logService.CreateLog(logRoom);
                            logger.LogInformation("Affectation de la salle {RoomName} à l'élève {StudentFullName} par l'utilisateur {UserName} sur le poste {IpAddress}",
                                                  studentRoom.Room.Name,
                                                  studentRoom.Student.FullName,
                                                  clientApp.UserConnected.UserName,
                                                  clientApp.IpAddress
                            );
                        }
                    }      
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                this.SaveButton.Enabled = true;
            }
            
        }
        // show student UI for edit
        private void ShowStudentEditForm(Student student)
        {
            if (student != null)
            {
                var form = Program.ServiceProvider.GetService<EditStudentForm>();
                form.Text = Language.labelUpdate + ":.. " + Language.labelStudent;
                form.Icon = this.Icon;
                form.Init(student);
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    var item = new RadListDataItem
                    {
                        Text = $"{student.LastName} {student.FirstName} | {student.IdNumber}",
                        Value = student.Id,
                        Image = File.Exists(student.PictureUrl) ? new Bitmap(Image.FromFile(student.PictureUrl), new Size(32, 32)) : new Bitmap(Helper.GetImage(Resources.no_image), new Size(32, 32)),
                        Tag = student
                    };
                    StudentDropDownList.Items.Clear();
                    StudentDropDownList.DataSource = null;
                    StudentDropDownList.Items.Add(item);
                    StudentDropDownList.SelectedValue = student.Id;
                }
            }
            else
            {
                RadMessageBox.Show(Language.messageUnknowGroup);
            }

        }
        // show student UI for add new
        private void ShowStudentAddForm()
        {
            var form = Program.ServiceProvider.GetService<AddStudentForm>();
            form.Text = Language.labelAdd + ":.. " + Language.labelStudent;
            form.Icon = this.Icon;
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                var data = studentService.GetStudentAsync(form.IdNumberTextBox.Text).Result;
                Program.StudentList.Add(data);
                StudentDropDownList.DataSource = null;
                StudentDropDownList.DataSource = Program.StudentList;
                StudentDropDownList.SelectedValue = data;
            }
        }
        // show class UI for edit
        private void ShowSchoolClassEditForm(SchoolClass record)
        {
            if (record != null)
            {
                var form = Program.ServiceProvider.GetService<EditSchoolClassForm>();
                form.Text = Language.labelUpdate + ":.. " + Language.labelClass;
                form.Icon = this.Icon;
                form.InitStartup(record);
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    var data = classService.GetSchoolClass(form.NameTextBox.Text).Result;
                    ClassDropDownList.DataSource = null;
                    ClassDropDownList.DataSource = Program.SchoolClassList;
                    ClassDropDownList.SelectedValue = data;
                }
            }
            else
            {
                RadMessageBox.Show(Language.messageUnknowGroup);
            }

        }
        // show class UI for add new
        private void ShowSchoolClassAddForm()
        {
            var form = Program.ServiceProvider.GetService<AddSchoolClassForm>();
            form.Text = Language.labelAdd + ":.. " + Language.labelClass;
            form.Icon = this.Icon;
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                var data = classService.GetSchoolClass(form.NameTextBox.Text).Result;
                Program.SchoolClassList.Add(data);
                ClassDropDownList.DataSource = null;
                ClassDropDownList.DataSource = Program.SchoolClassList;
                ClassDropDownList.SelectedValue = data;
            }
        }
        // show room UI for edit
        private void ShowSchoolRoomEditForm(SchoolRoom record)
        {
            if (record != null)
            {
                var form = Program.ServiceProvider.GetService<EditSchoolRoomForm>();
                form.Text = Language.labelUpdate + ":.. " + Language.labelRoom;
                form.Icon = this.Icon;
                form.Init(record);
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    var data = roomService.GetSchoolRoom(form.NameTextBox.Text).Result;
                    RoomDropDownList.DataSource = null;
                    RoomDropDownList.DataSource = Program.SchoolRoomList;
                    RoomDropDownList.SelectedValue = data;
                }
            }
            else
            {
                RadMessageBox.Show(Language.messageUnknowGroup);
            }

        }
        // show room UI for add new
        private void ShowSchoolRoomAddForm()
        {
            var form = Program.ServiceProvider.GetService<AddSchoolRoomForm>();
            form.Text = Language.labelAdd + ":.. " + Language.labelRoom;
            form.Icon = this.Icon;
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                var data = roomService.GetSchoolRoom(form.NameTextBox.Text).Result;
                Program.SchoolRoomList.Add(data);
                RoomDropDownList.DataSource = null;
                RoomDropDownList.DataSource = Program.SchoolRoomList;
                RoomDropDownList.SelectedValue = data;
            }
        }

        private List<TuitionPayment> GetInitialPaymentList(int classId)
        {
            var recordList = new List<TuitionPayment>();
            //Récupération des frais  scolaires exigibles de l'année en cours.
            var feeList = Program.SchoolingCostList.Where(x => x.SchoolYearId == Program.CurrentSchoolYear.Id && x.IsPayable == true && x.SchoolClassId == classId).OrderBy(x => x.CashFlowType.Sequence).ToList();
            foreach (var fee in feeList)
            {
                recordList.Add(
                    new TuitionPayment()
                    {
                        CashFlowType = fee.CashFlowType,
                        CashFlowTypeId = fee.CashFlowType.Id,
                        Amount = 0,
                        Date = DateTime.Now,
                        TransactionDate = DateTime.Now,
                        PaymentMean = Program.PaymentMeanList.FirstOrDefault(),
                        PaymentMeanId = Program.PaymentMeanList.FirstOrDefault().Id,
                        Balance = feeList.Where(x => x.CashFlowTypeId == fee.CashFlowTypeId).Sum(x => x.Amount)
                    }
                    );
            }
            return recordList;
        }

        private void CheckPermissions()
        {
            this.AddStudentButton.Visible = Program.UserConnected.CanCreateStudent();
            this.AddClassButton.Visible = Program.UserConnected.HasSettingPagePermission();
            this.AddRoomButton.Visible = Program.UserConnected.HasSettingPagePermission();
        }

    }
}
