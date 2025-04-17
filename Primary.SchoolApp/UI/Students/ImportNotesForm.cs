

using Primary.SchoolApp.DTO;
using Primary.SchoolApp.Services;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using SchoolManagement.UI.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Primary.SchoolApp.UI
{
    internal class ImportNotesForm : SchoolManagement.UI.ImportNotesForm
    {
        private readonly IStudentNoteService studentNoteService;
        private readonly LocalStudentNoteService localStudentNoteService;
        private SchoolRoom selectedRoom;
        private SchoolClass selectedClass;
        private SchoolGroup selectedClassGroup;
        private EvaluationSession selectedSession;
        private int selectedBookId;
        private readonly ClientApp clientApp;
        private readonly ILogService logService;
        private string selectedFile;
        private List<Student> students;
        private DataTable notesTable;
        private string selectedLanguage = "FR";
        private IEnumerable<Subject> subjects;
        private readonly List<InfoItem> infoList;
        private readonly BackgroundWorker backgroundWorker;
        private readonly List<(int Row, int Column, string ErrorMessage)>errorSaveList; 
        public ImportNotesForm(IStudentNoteService studentNoteService, ILogService logService, ClientApp clientApp, LocalStudentNoteService localStudentNoteService)
        {
            this.studentNoteService = studentNoteService;
            this.logService = logService;
            this.clientApp = clientApp;
            this.localStudentNoteService = localStudentNoteService;
            infoList = new();
            backgroundWorker = new()
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            InitDataGridView();
            this.InfoListControl.DisplayMember = "Title";
            errorSaveList=new();
        }

        private void InitDataGridView()
        {
            DataGridView.ReadOnly = true;
            DataGridView.AllowColumnChooser = false;
            DataGridView.ShowFilteringRow = false;
            DataGridView.AllowAddNewRow = false;
            DataGridView.AllowDragToGroup = false;
            DataGridView.EnableCustomFiltering = true;
            DataGridView.EnableFiltering = true;
            DataGridView.TableElement.TableHeaderHeight = 150;
        }

        private void ClassroomDropDownList_SelectedValueChanged(object sender, Telerik.WinControls.UI.Data.ValueChangedEventArgs e)
        {
            if (ClassroomDropDownList.SelectedItem != null)
            {
                if (ClassroomDropDownList.SelectedItem.DataBoundItem is SchoolRoom room)
                {
                    selectedRoom = room;
                    selectedClass = Program.SchoolClassList.FirstOrDefault(x => x.Id == room.ClassId);
                    selectedClassGroup = Program.SchoolGroupList.FirstOrDefault(x => x.Id == selectedClass.GroupId);
                    students = Program.StudentRoomList.Where(x => x.SchoolYearId == Program.CurrentSchoolYear.Id && x.RoomId == room.Id).Select(x => x.Student).OrderBy(x => x.FullName).ToList();
                    LoadClassSection();
                }
            }
        }
        internal void InitStartup(SchoolRoom room, EvaluationSession session, int bookId)
        {
            selectedRoom = room;
            selectedSession = session;
            selectedBookId = bookId;
            EvaluationLabel.Text = Thread.CurrentThread.CurrentUICulture.Name == "en-GB" ? session.EnglishName : session.FrenchName;
            students = Program.StudentRoomList.Where(x => x.SchoolYearId == Program.CurrentSchoolYear.Id && x.RoomId == room.Id).Select(x => x.Student).OrderBy(x => x.FullName).ToList();
            selectedClass = Program.SchoolClassList.FirstOrDefault(x => x.Id == room.ClassId);
            selectedClassGroup = Program.SchoolGroupList.FirstOrDefault(x => x.Id == selectedClass.GroupId);
            ClassroomDropDownList.DataSource = MainForm.GetUserConnectedClassrooms();
            ClassroomDropDownList.ValueMember = "Id";
            ClassroomDropDownList.DisplayMember = "Name";
            ClassroomDropDownList.SelectedValue = room.Id;
            LoadClassSection();
            students = Program.StudentRoomList.Where(x => x.SchoolYearId == Program.CurrentSchoolYear.Id && x.RoomId == room.Id).Select(x => x.Student).OrderBy(x => x.FullName).ToList();
            subjects = Program.ClassSubjectList.Where(x => x.ClassId == room.ClassId && x.BookId == selectedBookId).Select(x => x.Subject);
            InitEvent();

        }

        private void InitEvent()
        {
            ClassroomDropDownList.SelectedValueChanged += ClassroomDropDownList_SelectedValueChanged;
            GroupDropDownList.SelectedValueChanged += GroupDropDownList_SelectedValueChanged;
            ImportButton.Click += async (sender, e) => await ImportButton_Click(sender, e);
            DataGridView.ViewCellFormatting += DataGridView_ViewCellFormatting;
            DataGridView.CellFormatting += DataGridView_CellFormatting;
            SaveButton.Click += SaveButton_Click;
            InfoListControl.CreatingVisualListItem += InfoListConstrol_CreatingVisualListItem;
            InfoListControl.VisualItemFormatting += InfoListConstrol_VisualItemFormatting;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
        }

        

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = SaveNotes();
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.InfoListControl.DataSource = new List<InfoItem>();
            this.TaskWaitingBar.StopWaiting();
            this.TaskWaitingBar.Visibility = ElementVisibility.Hidden;
            this.ImportButton.Enabled = true;
            this.SaveButton.Enabled = true;
            this.ClassroomDropDownList.Enabled = true;
            this.GroupDropDownList.Enabled = true;
            if (e.Cancelled)
            {
                infoList.Add(new()
                {
                    Title = "Enregistrement des notes",
                    Description = "Enregistrement des notes annulé!",
                    Color = "Red"
                });
            }
            else if (e.Error != null)
            {
                infoList.Add(new()
                {
                    Title = "Enregistrement des notes",
                    Description = $"Erreur d'enregistrement des notes {e.Error.Message}",
                    Color = "Red"
                });

            }
            else
            {
                infoList.Add(new()
                {
                    Title = "Enregistrement des notes",
                    Description = $"Total des notes importées dans le système {e.Result}",
                    Color = "Green"
                });
            }
            this.InfoListControl.DataSource = infoList;
            this.InfoPanel.Visible = true;
            IndicateErrorInDataGridView();
        }

        // Signale les notes qui n'ont été enregistrés 
        private void IndicateErrorInDataGridView()
        {
            foreach(var error in errorSaveList)
            {
                Console.WriteLine(error.ErrorMessage);
                int row = error.Row;
                int column = error.Column;

                string columnError = error.ErrorMessage;
                string rowError = error.ErrorMessage;
                //IDataErrorInfo dataErrorInfo = this.DataGridView.Rows[row].DataBoundItem as IDataErrorInfo;
                this.DataGridView.Rows[row].ErrorText = rowError;
                this.DataGridView.Rows[row].Cells[column].ErrorText = columnError;
            }
        }
        private void InfoListConstrol_VisualItemFormatting(object sender, VisualItemFormattingEventArgs args)
        {
            RadListDataItem item = args.VisualItem.Data;
            if (item != null)
            {
                if (Convert.ToBoolean(item.Tag))
                {
                    //the item is read, mark it
                    InfoItemElement el = args.VisualItem as InfoItemElement;
                    //el.HeaderElement.Font = markAsReadFont;
                }
                else
                {
                    //reset setting 
                    InfoItemElement el = args.VisualItem as InfoItemElement;
                    el.HeaderElement.ResetValue(LightVisualElement.FontProperty, ValueResetFlags.Local);
                }
            }
        }

        private void InfoListConstrol_CreatingVisualListItem(object sender, CreatingVisualListItemEventArgs args)
        {
            args.VisualItem = new InfoItemElement();
        }


        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (IsValidImportData())
                {
                    if (backgroundWorker.IsBusy != true)
                    {
                        this.TaskWaitingBar.StartWaiting();
                        this.TaskWaitingBar.Visibility = ElementVisibility.Visible;
                        this.ImportButton.Enabled= false;
                        this.SaveButton.Enabled= false;
                        this.ClassroomDropDownList.Enabled= false;
                        this.GroupDropDownList.Enabled= false;
                        backgroundWorker.RunWorkerAsync();
                    }
                }
            }
        }

        private void GroupDropDownList_SelectedValueChanged(object sender, Telerik.WinControls.UI.Data.ValueChangedEventArgs e)
        {
            if (int.TryParse(GroupDropDownList.SelectedValue.ToString(), out selectedBookId))
            {
                selectedLanguage = LocalStudentNoteService.GetLanguageGroup(selectedClassGroup, selectedBookId);
            }
        }

        private void DataGridView_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement is GridHeaderCellElement)
            {
                if (e.Column.Index > 1)
                {
                    e.Column.AutoSizeMode = BestFitColumnMode.AllCells;
                    e.CellElement.MinSize = new System.Drawing.Size(30, 150);
                    e.CellElement.TextOrientation = Orientation.Vertical;
                    e.CellElement.FlipText = true;
                    e.CellElement.TextWrap = true;
                }
                if (e.Column.HeaderText.Contains("#"))
                {
                    var newText = e.Column.HeaderText.Replace('#', '.');
                    e.Column.HeaderText = newText;
                }

            }
        }
        private void DataGridView_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            GridDataCellElement cell = e.CellElement as GridDataCellElement;
            if (cell != null)
            {
                if (cell.ContainsErrors)
                {
                    cell.DrawBorder = true;
                    cell.BorderBoxStyle = BorderBoxStyle.FourBorders;

                    cell.BorderBottomColor = cell.BorderTopColor = cell.BorderRightShadowColor = cell.BorderLeftShadowColor =
                            cell.BorderBottomShadowColor = cell.BorderTopShadowColor = cell.BorderRightColor = cell.BorderLeftColor = Color.Red;
                    cell.BorderBottomWidth = cell.BorderTopWidth = cell.BorderRightWidth = cell.BorderLeftWidth = 2;

                    cell.ZIndex = 500;
                }
                else
                {
                    cell.ResetValue(LightVisualElement.DrawBorderProperty, ValueResetFlags.Local);
                    cell.ResetValue(LightVisualElement.BorderBoxStyleProperty, ValueResetFlags.Local);

                    cell.ResetValue(LightVisualElement.BorderBottomColorProperty, ValueResetFlags.Local);
                    cell.ResetValue(LightVisualElement.BorderBottomShadowColorProperty, ValueResetFlags.Local);
                    cell.ResetValue(LightVisualElement.BorderBottomWidthProperty, ValueResetFlags.Local);

                    cell.ResetValue(LightVisualElement.BorderTopColorProperty, ValueResetFlags.Local);
                    cell.ResetValue(LightVisualElement.BorderTopShadowColorProperty, ValueResetFlags.Local);
                    cell.ResetValue(LightVisualElement.BorderTopWidthProperty, ValueResetFlags.Local);

                    cell.ResetValue(LightVisualElement.BorderLeftColorProperty, ValueResetFlags.Local);
                    cell.ResetValue(LightVisualElement.BorderLeftShadowColorProperty, ValueResetFlags.Local);
                    cell.ResetValue(LightVisualElement.BorderLeftWidthProperty, ValueResetFlags.Local);

                    cell.ResetValue(LightVisualElement.BorderDrawModeProperty, ValueResetFlags.Local);
                    cell.ResetValue(LightVisualElement.ZIndexProperty, ValueResetFlags.Local);
                }
            }
        }
        private void LoadClassSection()
        {
            GroupDropDownList.Items.Clear();
            if (selectedClass != null)
            {
                if (selectedClassGroup.DocumentLanguageId == 2)
                {
                    GroupDropDownList.Items.Add(new RadListDataItem("Francophone", 0));
                    GroupDropDownList.Items.Add(new RadListDataItem("Anglophone", 1));
                }
                else
                {
                    if (selectedClassGroup.DocumentLanguageId == 0)
                    {
                        GroupDropDownList.Items.Add(new RadListDataItem("Francophone", 0));
                    }
                    else
                    {
                        GroupDropDownList.Items.Add(new RadListDataItem("Anglophone", 0));
                    }
                }
                GroupDropDownList.SelectedIndex = selectedBookId;
                selectedLanguage = LocalStudentNoteService.GetLanguageGroup(selectedClassGroup, selectedBookId);
            }

        }

        private async Task ImportButton_Click(object sender, EventArgs e)
        {

            OpenFileDialog file = new(); //open dialog to choose file  
            file.Filter = "Fichier Excel (*.xls;*.xlsx)|*.xls;*.xlsx|Tous les fichiers (*.*)|*.*";
            if (file.ShowDialog() == DialogResult.OK) //if there is a file choosen by the user  
            {
                string filePath = file.FileName;
                string fileExtension = Path.GetExtension(filePath);
                if (fileExtension.CompareTo(".xls") == 0 || fileExtension.CompareTo(".xlsx") == 0)
                {
                    Task task;
                    DataGridView.DataSource = new DataTable();
                    this.TaskWaitingBar.StartWaiting();
                    this.TaskWaitingBar.Visibility = ElementVisibility.Visible;
                    selectedFile = filePath;
                    task = Task.Run(ImportFile);
                    await task;
                    DataGridView.DataSource = notesTable;
                    DataGridView.BestFitColumns();
                    IsValidImportData();
                }
                else
                {
                    MessageBox.Show(Language.MessageSelectExcelFileOnly, "SCHOOL APP", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error  
                }
            }
        }
        // Importation du fichier de notes
        private void ImportFile()
        {
            var task = localStudentNoteService.ImportNotes(selectedFile, selectedRoom.Id, selectedBookId);
            notesTable = task.Result;
            this.TaskWaitingBar.StopWaiting();
            this.TaskWaitingBar.ResetWaiting();
            this.TaskWaitingBar.Visibility = ElementVisibility.Hidden;
            SaveButton.Visibility = ElementVisibility.Visible;
        }
        // Vérification de la validité des données extraites
        private bool IsValidImportData()
        {
            this.InfoListControl.DataSource = new List<InfoItem>();
            infoList.Clear();
            int infoCount = 0;

            if (notesTable.Rows.Count == 0)
            {
                infoList.Add(new()
                {
                    Title = "Importation des fichiers",
                    Description = "L'importation du fichier de notes est requise"
                }
                    );
                infoCount++;
            }
            if (ColumnIdIsPresent() == false)
            {
                infoCount++;
            }
            if (ColumnStudentIsPresent() == false)
            {
                infoCount++;
            }
            if (ColumnsSubjectIsPresent() == false)
            {
                infoCount++;
            }
            if (RowsNoteIsPresent() == false)
            {
                infoCount++;
            }
            if (SubjectsIsMoreThan() == false)
            {
                infoCount++;
            }
            if (SubjecstIsReal() == false)
            {
                infoCount++;
            }
            if (StudentstIsReal() == false)
            {
                infoCount++;
            }
            this.InfoListControl.DataSource = infoList;
            this.InfoPanel.Visible = infoCount != 0;

            return infoCount == 0;
        }
        private bool ColumnIdIsPresent()
        {
            if (notesTable.Columns.Count != 0)
            {
                var labelId = selectedLanguage == "FR" ? "MATRICULE" : "ID";

                if (notesTable.Columns[0].ToString() != labelId)
                {
                    infoList.Add(new()
                    {
                        Title = "Contôle des matricules",
                        Description = $"La colonne {labelId} est introuvable  dans le fichier importé "
                    }
                    );
                    return false;
                }
            }
            return true;
        }
        private bool ColumnStudentIsPresent()
        {
            if (notesTable.Columns.Count != 0)
            {
                var labelStudent = selectedLanguage == "FR" ? "ELEVE" : "STUDENT";
                if (notesTable.Columns[1].ToString() != labelStudent)
                {
                    infoList.Add(new()
                    {
                        Title = "Contôle des élèves",
                        Description = $"La colonne {labelStudent} est introuvable  dans le fichier importé "
                    }
                       );
                    return false;
                }
            }
            return true;
        }
        private bool SubjectsIsMoreThan()
        {
            if ((notesTable.Columns.Count - 3) > subjects.Count())
            {
                infoList.Add(new()
                {
                    Title = "Contôle des matières",
                    Description = $"Le nombre de matières du fichier importé est superieur nombre de matières enseignés"
                }
                );

                return false;
            }
            return true;
        }
        private bool ColumnsSubjectIsPresent()
        {
            if (notesTable.Columns.Count < 3)
            {
                infoList.Add(new()
                {
                    Title = "Contôle des matières",
                    Description = $"Les matières sont introuvables dans le fichier importé"
                }
               );
                return false;
            }
            return true;
        }
        private bool RowsNoteIsPresent()
        {
            if (notesTable.Rows.Count == 0)
            {
                infoList.Add(new()
                {
                    Title = "Contôle des notes",
                    Description = $"Les notes sont introuvables dans le fichier importé"
                }
               );
                return false;
            }
            return true;
        }
        private bool SubjecstIsReal()
        {
            int badSubjectNumber = 0;
            if (RowsNoteIsPresent())
            {
                var realSubjects = selectedLanguage == "EN" ? subjects.Select(s => s.EnglishName.TrimEnd()) : subjects.Select(s => s.FrenchName.TrimEnd());
                var importSubjects = new List<string>();
                //get subject list imported
                for (int k = 2; k < notesTable.Columns.Count; k++)
                {
                    if (notesTable.Columns[k].ToString().Trim().Contains("#"))
                    {
                        var newText = notesTable.Columns[k].ToString().Trim().Replace('#', '.');
                        notesTable.Columns[k].ColumnName = newText;
                    }
                    importSubjects.Add(notesTable.Columns[k].ToString().Trim());
                }

                // check if import subject exist in real subject list
                foreach (var subject in importSubjects)
                {
                    if (realSubjects.Contains(subject.TrimEnd()) == false)
                    {
                        infoList.Add(new()
                        {
                            Title = "Contôle des matières",
                            Description = $"La matière {subject} est introuvable dans la liste de matières pour {selectedRoom.Name}"
                        }
                       );
                        badSubjectNumber++;
                    }
                }
            }
            return badSubjectNumber == 0;
        }
        private bool StudentstIsReal()
        {
            int badStudentNumber = 0;
            if (RowsNoteIsPresent())
            {
                var realStudentIds = students.Select(s => s.IdNumber);

                var importStudentIds = new List<string>();
                //get student list imported
                for (int k = 0; k < notesTable.Rows.Count; k++)
                {
                    importStudentIds.Add(notesTable.Rows[k][0].ToString().Trim());
                }
                // check if import student exist in real subject list
                foreach (var id in importStudentIds)
                {
                    if (realStudentIds.Contains(id) == false)
                    {
                        infoList.Add(new()
                        {
                            Title = "Contôle des élèves",
                            Description = $"Le  matricule {id} introuvable dans la liste des élèves de la salle de classe {selectedRoom.Name}"
                        }
                       );
                        badStudentNumber++;
                    }
                }
            }
            return badStudentNumber == 0;
        }

        private string  SaveNotes()
        {
            infoList.Clear();
            errorSaveList.Clear();
            int totalSaved = 0;
            int totalToSave = 0;
            for (int i = 0; i < notesTable.Rows.Count; i++)
            {
                var student = students.Where(s => s.IdNumber == notesTable.Rows[i][0].ToString().Trim()).First();
                for (int k = 2; k < notesTable.Columns.Count; k++)
                {
                    if (notesTable.Rows[i][k].ToString().Trim() != string.Empty)
                    {
                        var subject = selectedLanguage != "EN" ? subjects.FirstOrDefault(s => s.FrenchName == notesTable.Columns[k].ToString().Trim())
                                       : subjects.FirstOrDefault(s => s.EnglishName == notesTable.Columns[k].ToString().Trim());
                       totalToSave++;
                        if (subject != null)
                        {
                            var subjectData = Program.ClassSubjectList.FirstOrDefault(x => x.ClassId == selectedRoom.ClassId && x.BookId == selectedBookId && x.SubjectId == subject.Id);
                            var subjectName = selectedLanguage != "EN" ? subject.FrenchName : subject.EnglishName;
                            var note = double.Parse(notesTable.Rows[i][k].ToString().Trim());
                            if (note <= subjectData.NotedOn) // la note ne doit pas être supérieure à la note max
                            {
                                var studentNote = new StudentNote
                                {

                                    Date = DateTime.Now,
                                    Note = note,
                                    NoteCoef = subjectData.Coefficient,
                                    NotedOn = subjectData.NotedOn,
                                    Comment = string.Empty,
                                    Student = student,
                                    StudentId = student.Id,
                                    Subject = subject,
                                    SubjectId = subject.Id,
                                    BookId = selectedBookId,
                                    SchoolYear = Program.CurrentSchoolYear,
                                    SchoolYearId = Program.CurrentSchoolYear.Id,
                                    Evaluation = selectedSession,
                                    EvaluationId = selectedSession.Id,
                                };
                                if (!NoteExist(studentNote))
                                {
                                    //enregistrement de la nouvelle note
                                    var isDone = studentNoteService.CreateStudentNoteAsync(studentNote).Result;
                                    if (isDone)
                                    {
                                        //enregistrement du log
                                        Log log = new()
                                        {
                                            UserAction = $"Ajout d'une note de {studentNote.Subject.FrenchName} pour {studentNote.Evaluation.FrenchName}  de l'élève {studentNote.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                                            UserId = clientApp.UserConnected.Id
                                        };
                                        logService.CreateLog(log);
                                        infoList.Add(new()
                                        {
                                            Title = "Enregistrement des notes",
                                            Description = $"L'importation de la note de la matière {subjectName}  de l'élève {student.FullName} dans le système a réussi",
                                            Color = "Green"
                                        }
                                        );
                                        totalSaved++;
                                    }
                                    else
                                    {
                                        infoList.Add(new()
                                        {
                                            Title = "Enregistrement des notes",
                                            Description = $"L'importation de la note de la matière {subjectName}  de l'élève {student.FullName} dans le système a   échoué",
                                            Color = "Red"
                                        }
                                        );
                                    }
                                }
                                else
                                {
                                    // Mise à jour
                                    studentNote = studentNoteService.GetNoteAsync(studentNote.SubjectId, studentNote.StudentId, studentNote.EvaluationId, studentNote.SchoolYearId, studentNote.BookId).Result;
                                    studentNote.Note = double.Parse(notesTable.Rows[i][k].ToString().Trim());
                                    var isDone = studentNoteService.UpdateStudentNoteAsync(studentNote).Result;
                                    if (isDone)
                                    {
                                        //enregistrement du log
                                        Log log = new()
                                        {
                                            UserAction = $"Mise à jour de la note de {studentNote.Subject.FrenchName} pour {studentNote.Evaluation.FrenchName}  de l'élève {studentNote.Student.FullName}  par l'utilisateur {clientApp.UserConnected.UserName} sur le poste {clientApp.IpAddress}",
                                            UserId = clientApp.UserConnected.Id
                                        };
                                        logService.CreateLog(log);
                                        infoList.Add(new()
                                        {
                                            Title = "Enregistrement des notes",
                                            Description = $"L'importation de la note de la matière {subjectName}  de l'élève {student.FullName} dans le système a réussi",
                                            Color = "Green"
                                        }
                                        );
                                        totalSaved++;
                                    }
                                    else
                                    {
                                        infoList.Add(new()
                                        {
                                            Title = "Enregistrement des notes",
                                            Description = $"L'importation de la note de la matière {subjectName}  de l'élève {student.FullName} dans le système a   échoué",
                                            Color = "Red"
                                        }
                                        );
                                    }
                                }
                            }
                            else
                            {
                                infoList.Add(new()
                                    {
                                        Title = "Enregistrement des notes",
                                        Description = $"La note({note}) de la matière {subjectName}  de l'élève {student.FullName} est supérieure à la note max({subjectData.NotedOn})",
                                        Color = "Red"
                                    }
                                );
                                errorSaveList.Add(new (i, k, $"La note({note}) de la matière {subjectName}  de l'élève {student.FullName} est supérieure à la note max({subjectData.NotedOn})"));
                            }
                        }
                    }

                }
            }
        return $"{totalSaved}/{totalToSave}";
        }

        private bool NoteExist(StudentNote note)
        {
            return studentNoteService.GetNoteAsync(note.SubjectId, note.StudentId, note.EvaluationId, note.SchoolYearId, note.BookId).Result != null;
        }
    }
}
