﻿using Primary.SchoolApp.UI;
using SchoolManagement.Application;
using SchoolManagement.Core.Model;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Linq;
using System;
using Microsoft.Extensions.DependencyInjection;
using Primary.SchoolApp.Utilities;
using SchoolManagement.UI.Localization;
using System.Collections.Generic;
using Telerik.WinControls.UI;
using Telerik.WinControls.Enumerations;
using System.ComponentModel;
using Telerik.WinControls.Data;
using Primary.SchoolApp.CustomElements;
using Primary.SchoolApp.UI.CustomControls;
using System.IO;
using System.Drawing;
using Telerik.Windows.Diagrams.Core;
using Primary.SchoolApp.DTO;
using Primary.SchoolApp.Services;
using System.Diagnostics;
using MediaFoundation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using SchoolManagement.Application.Subscriptions;
namespace Primary.SchoolApp
{
    public partial class MainForm : SchoolManagement.UI.MainForm
    {
        private StudentEnrollingInfo studentEnrollingInfo;
        private string homeLeftViewForToolTipText;
        private bool updatingHomeToggleState = false;
        private bool isLogOut;// si true se deconnecter
        private readonly ISchoolYearService schoolYearService;
        private readonly ISchoolGroupService schoolGroupService;
        private readonly ISchoolClassService schoolClassService;
        private readonly ISchoolRoomService schoolRoomService;
        private readonly ICashFlowTypeService cashFlowTypeService;
        private readonly IPaymentMeanService paymentMeanService;
        private readonly ISchoolingCostService schoolingCostService;
        private readonly ISubscriptionFeeService subscriptionFeeService;
        private readonly ISubjectGroupService subjectGroupService;
        private readonly ISubjectService subjectService;
        private readonly IEvaluationSessionService evaluationSessionService;
        private readonly ClientApp clientApp;
        private readonly ILogService logService;
        private readonly IRatingSystemService ratingSystemService;
        private readonly IJobService jobService;
        private readonly IEmployeeGroupService employeeGroupService;
        private readonly IUserService userService;
        private readonly IEmployeeService employeeService;
        private readonly IModuleService moduleService;
        private readonly ICountryService countryService;
        private readonly ITimeTableService timeTableService;
        private readonly IPrintService printService;
        private readonly IStudentEnrollingService studentEnrollingService;
        private readonly ICashFlowService cashFlowService;
        private readonly ISubscriptionService subscriptionService;
        private readonly LocalEnrollingService localEnrollingService;
        private readonly IDisciplineService disciplineService;
        private readonly IContactService contactService;
        public MainForm(ISchoolYearService schoolYearService, ISchoolGroupService schoolGroupService,
            ISchoolClassService schoolClassService, ISchoolRoomService schoolRoomService, ICashFlowTypeService cashFlowTypeService
            , IPaymentMeanService paymentMeanService, ISchoolingCostService schoolingCostService, ISubscriptionFeeService subscriptionFeeService
            , ISubjectGroupService subjectGroupService, ISubjectService subjectService, IEvaluationSessionService evaluationSessionService,
            ClientApp clientApp, ILogService logService, IRatingSystemService ratingSystemService, IJobService jobService, IEmployeeGroupService employeeGroupService,
            IUserService userService, IEmployeeService employeeService, IModuleService moduleService, ICountryService countryService, ITimeTableService timeTableService,
            IStudentEnrollingService studentEnrollingService, IPrintService printService, ICashFlowService cashFlowService, ISubscriptionService subscriptionService,
            IDisciplineService disciplineService, IContactService contactService
            )
        {
            this.schoolYearService = schoolYearService;
            this.schoolGroupService = schoolGroupService;
            this.schoolClassService = schoolClassService;
            this.schoolRoomService = schoolRoomService;
            this.cashFlowTypeService = cashFlowTypeService;
            this.paymentMeanService = paymentMeanService;
            this.schoolingCostService = schoolingCostService;
            this.subscriptionFeeService = subscriptionFeeService;
            this.subjectGroupService = subjectGroupService;
            this.subjectService = subjectService;
            this.evaluationSessionService = evaluationSessionService;
            this.ratingSystemService = ratingSystemService;
            this.jobService = jobService;
            this.clientApp = clientApp;
            this.logService = logService;
            this.employeeGroupService = employeeGroupService;
            this.userService = userService;
            this.employeeService = employeeService;
            this.moduleService = moduleService;
            this.countryService = countryService;
            this.timeTableService = timeTableService;
            this.studentEnrollingService = studentEnrollingService;
            this.cashFlowService = cashFlowService;
            this.printService = printService;
            this.subscriptionService = subscriptionService;
            this.disciplineService =disciplineService;
            this.contactService= contactService;
            localEnrollingService = new LocalEnrollingService();
            LoadBasicData();
            InitHomePage();
            InitTimeTablePage();
            InitSettingPage();
            InitMainEvents();
            InitEmployeePage();

        }

        private void InitHomePage()
        {
            HomeIconViewToggleButton.ToggleState = ToggleState.On;
            InitGridViewHomePage();
            InitHomeMainListView();
            InitContextHomePage();
            InitHomePageCustomControls();
            LoadDataToHomeLeftListView();
            InitEventsHomePage();
            LoadEnrollingStudentList();
        }
        private void InitMainEvents()
        {
            AboutButton.Click += AboutButton_Click;
            ChangePasswordMenu.Click += ChangePasswordMenu_Click;
            LogOutMenu.Click += LogOutMenu_Click;
            FormClosing += MainForm_FormClosing;
            ThemesDropDownList.SelectedIndexChanged += ThemesDropDownList_SelectedIndexChanged;
            this.Shown += MainForm_Shown;
            this.Load += MainForm_Load;
            ThemeResolutionService.ApplicationThemeChanged += ThemeResolutionService_ApplicationThemeChanged;
        }
        private void InitEventsHomePage()
        {
            this.HomeSchoolYearDropDownList.SelectedValueChanged += HomeSchoolYearDropDownList_SelectedValueChanged;
            HomeAddButton.Click += HomeAddButton_Click;
            HomeListViewToggleButton.ToggleStateChanged += HomeToggleButton_ToggleStateChanged;
            HomeIconViewToggleButton.ToggleStateChanged += HomeToggleButton_ToggleStateChanged;
            HomeListViewToggleButton.ToggleStateChanging += HomeToggleButton_ToggleStateChanging;
            HomeIconViewToggleButton.ToggleStateChanging += HomeToggleButton_ToggleStateChanging;
            HomeMainListView.VisualItemCreating += HomeMainListView_VisualItemCreating;
            HomeMainListView.GroupExpanding += HomeMainListView_GroupExpanding;
            HomeLeftListView.ItemCheckedChanged += HomeLeftListView_ItemCheckedChanged;
            HomeMainListView.CurrentItemChanged += HomeMainListView_CurrentItemChanged;
            HomeGridView.CurrentRowChanged += HomeGridView_CurrentRowChanged;
            HomeSearchTextBox.TextChanged += HomeSearchTextBox_TextChanged;
            HomeGridView.CustomFiltering += HomeGridView_CustomFiltering;
            HomeGridView.ContextMenuOpening += HomeGridView_ContextMenuOpening;
            HomeLeftListView.ItemMouseHover += HomeLeftListView_ItemMouseHover;
            HomeLeftListView.ToolTipTextNeeded += HomeLeftListView_ToolTipTextNeeded;
            HomeLeftListView.VisualItemCreating += HomeLeftListView_VisualItemCreating;
            HomeMainListView.ItemMouseClick += HomeMainListView_ItemMouseClick;
        }

        private void ThemesDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            AppUtilities.MainThemeColor = this.FormElement.TitleBar.FillPrimitive.BackColor;
            AjustColorTimeTablePage();
            HomeMainListView.ListViewElement.SynchronizeVisualItems();
            EmployeeMainListView.ListViewElement.SynchronizeVisualItems();
        }


        #region Events
        //inscription d'un élève
        private void HomeAddButton_Click(object sender, EventArgs e)
        {
            ShowAddStudentEnrollingForm();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            AppUtilities.MainThemeColor = FormElement.TitleBar.FillPrimitive.BackColor;
            //fire event to load data to Scheduler
            TimeTableLeftListView.SelectedIndex = 0;
        }

        private void ThemeResolutionService_ApplicationThemeChanged(object sender, ThemeChangedEventArgs args)
        {
            InitAppointmentBackground();
        }
        // Affichage de l'IU pricipale
        private void MainForm_Shown(object sender, EventArgs e)
        {
            TimeTableDateNavigator.Location = new System.Drawing.Point(350, 10);
            TimeTableDateNavigator.Size = new System.Drawing.Size(350, 60);
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isLogOut)
            {
                LogOut();
            }
        }
        //déconnexion du systeème
        private void LogOutMenu_Click(object sender, System.EventArgs e)
        {
            LogOut();
        }
        //changement du mot de passe
        private void ChangePasswordMenu_Click(object sender, System.EventArgs e)
        {
            var form = Program.ServiceProvider.GetService<EditUserPasswordForm>();
            form.Text = Language.labelUpdate + ":.. " + Language.labelPassword;
            form.Icon = this.Icon;
            form.Init(clientApp.UserConnected.Id);
            form.ShowDialog(this);
        }
        //affiche la boite de dialog about
        private void AboutButton_Click(object sender, System.EventArgs e)
        {
            var form = new AboutAppForm();
            form.ShowDialog();
        }
        //permet de changer de vue:vue list, vue icon
        private void HomeToggleButton_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (updatingHomeToggleState)
            {
                return;
            }

            this.updatingHomeToggleState = true;
            if (HomeIconViewToggleButton != sender)
            {
                HomeIconViewToggleButton.ToggleState = ToggleState.Off;
            }
            if (HomeListViewToggleButton != sender)
            {
                HomeListViewToggleButton.ToggleState = ToggleState.Off;
            }
            this.updatingHomeToggleState = false;

            if (HomeIconViewToggleButton.ToggleState == ToggleState.On)
            {
                HomeGridView.Visible = false;
                HomeMainListView.Visible = true;
            }

            if (HomeListViewToggleButton.ToggleState == ToggleState.On)
            {

                HomeGridView.Visible = true;
                HomeMainListView.Visible = false;

            }
        }
        private void HomeToggleButton_ToggleStateChanging(object sender, StateChangingEventArgs args)
        {
            if (!updatingHomeToggleState && args.OldValue == ToggleState.On)
            {
                args.Cancel = true;
            }
        }
        //Selectionne une année scolaire
        private void HomeSchoolYearDropDownList_SelectedValueChanged(object sender, System.EventArgs e)
        {
            if (HomeSchoolYearDropDownList.SelectedItem != null)
            {
                if (HomeSchoolYearDropDownList.SelectedItem.DataBoundItem is SchoolYear schoolYear)
                {
                    Program.CurrentSchoolYear = schoolYear;
                    // add cashflow type for insolvable and solvable
                    LoadCashFlowTypeListToHomeLeftView();
                    //load student enrolling data
                    LoadEnrollingStudentList();

                }
            }
        }

        private void HomeMainListView_VisualItemCreating(object sender, ListViewVisualItemCreatingEventArgs e)
        {
            if (e.VisualItem is IconListViewVisualItem)
            {

                e.VisualItem = new HomeIconListViewVisualItem();
            }
        }
        private void HomeMainListView_GroupExpanding(object sender, ListViewGroupCancelEventArgs e)
        {
            e.Cancel = e.Group.Expanded;
        }
        private void HomeMainListView_CurrentItemChanged(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.DataBoundItem is DTO.StudentEnrollingDTO record)
            {
                foreach (var row in HomeGridView.Rows)
                {
                    var item = row.DataBoundItem as DTO.StudentEnrollingDTO;
                    if (item.Id == record.Id)
                    {
                        HomeGridView.CurrentRow = row;
                        break;
                    }
                }
            }
        }
        private void HomeMainListView_ItemMouseClick(object sender, ListViewItemEventArgs e)
        {
            e.ListViewElement.SelectedItem = e.Item;
        }

        private void HomeLeftListView_ItemCheckedChanged(object sender, ListViewItemEventArgs e)
        {
            UpdateHomeMainListView();
            HomeGridView.MasterTemplate.Refresh();
            HomeMainListView.ListViewElement.SynchronizeVisualItems();
        }
        private void HomeLeftListView_ItemMouseHover(object sender, ListViewItemEventArgs e)
        {
            homeLeftViewForToolTipText = "" + e.Item.Tag;
        }
        //affiche info bul pour 
        private void HomeLeftListView_ToolTipTextNeeded(object sender, Telerik.WinControls.ToolTipTextNeededEventArgs e)
        {
            try
            {
                e.Offset = new System.Drawing.Size(e.Offset.Width + 20, e.Offset.Height + 20);
                e.ToolTipText = homeLeftViewForToolTipText;
            }
            catch
            {
            }
        }
        private void HomeLeftListView_VisualItemCreating(object sender, ListViewVisualItemCreatingEventArgs e)
        {
            if (e.VisualItem is SimpleListViewVisualItem)
            {
                e.VisualItem = new HomeSimpleListViewVisualItem();
            }
        }

        private void HomeGridView_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            if (e.CurrentRow != null)
            {
                if (e.CurrentRow.DataBoundItem is DTO.StudentEnrollingDTO record)
                {
                    LoadSelectedStudentEnrollingDetail(record);
                }
            }
        }
        // filtre la liste des données présente dans le data grid view
        private void HomeGridView_CustomFiltering(object sender, GridViewCustomFilteringEventArgs e)
        {
            HomeGridViewCustomFiltering(e);
            //e.Handled = true;
            //var record = e.Row.DataBoundItem as DTO.StudentEnrollingDTO;
            //e.Visible = IsStudentByGroupChecked(e.Row.Cells["ClassGroupName"].Value.ToString());
            //e.Visible &= IsStudentByClassChecked(e.Row.Cells["ClassName"].Value.ToString());
            //e.Visible &= IsStatusHealthChecked(e.Row.Cells["Student.Health"].Value.ToString());
            //e.Visible &= IsStatusPaymentChecked(record);
            //e.Visible &= IsStatusInsolvencyChecked(record);
            //e.Visible &= IsStatusSolvencyChecked(record);
            //e.Visible &= IsStudentStatusChecked(record);
            //if (this.EmployeeSearchTextBox.Text != null)
            //{
            //    e.Visible &= e.Row.Cells["Student.IdNumber"].Value.ToString().Contains(HomeSearchTextBox.Text.ToLower()) ||
            //         e.Row.Cells["Student.FullName"].Value.ToString().ToLower().Contains(HomeSearchTextBox.Text.ToLower()) ||
            //         e.Row.Cells["ClassGroupName"].Value.ToString().ToLower().Contains(HomeSearchTextBox.Text.ToLower()) ||
            //         e.Row.Cells["ClassName"].Value.ToString().ToLower().Contains(HomeSearchTextBox.Text.ToLower());
            //}
        }

        private async void HomeGridViewCustomFiltering(GridViewCustomFilteringEventArgs e)
        {
            e.Handled = true;
            var record = e.Row.DataBoundItem as DTO.StudentEnrollingDTO;
            e.Visible = IsStudentByGroupChecked(e.Row.Cells["ClassGroupName"].Value.ToString());
            e.Visible &= IsStudentByClassChecked(e.Row.Cells["ClassName"].Value.ToString());
            e.Visible &= IsStatusHealthChecked(e.Row.Cells["Student.Health"].Value.ToString());
            e.Visible &= IsStatusPaymentChecked(record);
            e.Visible &= IsStatusInsolvencyChecked(record);
            e.Visible &= IsStatusSolvencyChecked(record);
            e.Visible &= IsStudentStatusChecked(record);
            if (this.EmployeeSearchTextBox.Text != null)
            {
                e.Visible &= e.Row.Cells["Student.IdNumber"].Value.ToString().Contains(HomeSearchTextBox.Text.ToLower()) ||
                     e.Row.Cells["Student.FullName"].Value.ToString().ToLower().Contains(HomeSearchTextBox.Text.ToLower()) ||
                     e.Row.Cells["ClassGroupName"].Value.ToString().ToLower().Contains(HomeSearchTextBox.Text.ToLower()) ||
                     e.Row.Cells["ClassName"].Value.ToString().ToLower().Contains(HomeSearchTextBox.Text.ToLower());
            }
            await System.Threading.Tasks.Task.Delay(0);
        }
        //recherche des données correspondantes pour lancer des filtres
        private void HomeSearchTextBox_TextChanged(object sender, System.EventArgs e)
        {
            HomeGridView.MasterTemplate.Refresh();
            if (HomeSearchTextBox.Text == string.Empty)
            {
                HomeMainListView.FilterPredicate = null;
            }
            else
            {
                HomeMainListView.FilterPredicate = null;
                HomeMainListView.FilterPredicate = FilterHomePredicate;
            }
            HomeLeftListView.ListViewElement.SynchronizeVisualItems();
            UpdateHomeMainListView();
        }

        private void MenuShowSubscriptions_Click(object sender, EventArgs e)
        {
            if (HomeGridView.CurrentRow.DataBoundItem is StudentEnrollingDTO enrollingDTO)
            {
                ShowSubscriptionsForm(enrollingDTO);
            }
        }

        private void MenuShowHealthFile_Click(object sender, EventArgs e)
        {
            RadMessageBox.Show("en cours de programmation....");
        }

        private void MenuShowContacts_Click(object sender, EventArgs e)
        {
            if(HomeGridView.CurrentRow.DataBoundItem is StudentEnrollingDTO enrolling)
            {
                var form = Program.ServiceProvider.GetService<ContactsForm>();
                form.Text = enrolling.Student.FullName + ": " + Language.labelSubscriptions;
                form.Icon = this.Icon;
                form.Init(enrolling.ConvertToStudentEnrolling());
                form.Show();
            }
        }
        private void MenuAddContact_Click(object sender, EventArgs e)
        {
            if (HomeGridView.CurrentRow.DataBoundItem is StudentEnrollingDTO enrolling)
            {
                var form = Program.ServiceProvider.GetService<AddContactForm>();
                form.Text = enrolling.Student.FullName + ": " + Language.labelSubscriptions;
                form.Icon = this.Icon;
                form.Init(enrolling.ConvertToStudentEnrolling().Student);
                form.Show();
            }
        }
        private void StudentEnrollingEditButton_Click(object sender, EventArgs e)
        {
            if (HomeGridView.CurrentRow != null)
            {
                if (HomeGridView.CurrentRow.DataBoundItem is StudentEnrollingDTO enrolling)
                {
                    ShowEditStudentEnrollingForm(enrolling);
                }
            }
        }
        private void MenuAddStudentPicture_Click(object sender, EventArgs e)
        {
            if (HomeGridView.CurrentRow != null)
            {
                if (HomeGridView.CurrentRow.DataBoundItem is StudentEnrollingDTO record)
                {
                    ShowUploadStudentPictureForm(record);
                }
            }
        }
        private void HomeGridView_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            if (!e.ContextMenuProvider.ToString().Contains("Header"))
            {
                RadMenuItem menuEdit = new(Language.labelEdit);
                RadMenuItem menuPrint = new(Language.labelPrintRegistrationReceipt);
                RadMenuItem menuAddPicture = new(Language.labelAddPicture);
                RadMenuItem menuSchoolFee = new(Language.labelSchoolingFee);
                RadMenuItem menuAddPayment = new(Language.labelAddPayment);
                RadMenuItem menuShowPayments = new(Language.labelShowPayments);
                RadMenuItem menuPrintPaymentSummary = new(Language.labelPrintSummaryPayment);
                RadMenuItem menuShowDiscounts = new(Language.labelShowDiscounts);
                RadMenuItem menuAddDiscount = new(Language.labelAddDiscount);
                RadMenuItem menuSubscription= new(Language.labelSubscription);
                RadMenuItem menuAddSubscription = new(Language.labelAddSubscription);
                RadMenuItem menuShowSubscriptions = new(Language.labelShowSubscriptions);
                RadMenuItem menuDiscipline = new(Language.labelDiscipline);
                RadMenuItem menuAddDiscipline = new(Language.labelAddDiscipline);
                RadMenuItem menuShowDisciplines = new(Language.labelShowDiscipline);
                RadMenuItem menuContact = new(Language.labelContact);
                RadMenuItem menuAddContact = new(Language.labelAddContact);
                RadMenuItem menuShowContacts = new(Language.labelShowContact);
                menuEdit.Image = AppUtilities.GetImage("Edit");
                menuPrint.Image = AppUtilities.GetImage("Printer");
                menuAddPicture.Image = AppUtilities.GetImage("Add");
                menuAddPayment.Image = AppUtilities.GetImage("Add");
                menuShowPayments.Image = AppUtilities.GetImage("View");
                menuPrintPaymentSummary.Image = AppUtilities.GetImage("Printer");
                menuShowDiscounts.Image = AppUtilities.GetImage("View");
                menuAddDiscount.Image = AppUtilities.GetImage("Add");
                menuShowSubscriptions.Image = AppUtilities.GetImage("View");
                menuAddSubscription.Image= AppUtilities.GetImage("Add");
                menuAddDiscipline.Image = AppUtilities.GetImage("Add");
                menuShowDisciplines.Image = AppUtilities.GetImage("View");
                menuAddContact.Image = AppUtilities.GetImage("Add");
                menuShowContacts.Image = AppUtilities.GetImage("View");

                menuSchoolFee.Items.Add(menuAddPayment);
                menuSchoolFee.Items.Add(menuShowPayments);
                menuSchoolFee.Items.Add(menuPrintPaymentSummary);
                menuSchoolFee.Items.Add(new RadMenuSeparatorItem());
                menuSchoolFee.Items.Add(menuAddDiscount);
                menuSchoolFee.Items.Add(menuShowDiscounts);
                menuSubscription.Items.Add(menuAddSubscription);
                menuSubscription.Items.Add(menuShowSubscriptions);
                menuDiscipline.Items.Add(menuAddDiscipline);
                menuDiscipline.Items.Add(menuShowDisciplines);
                menuContact.Items.Add(menuAddContact);
                menuContact.Items.Add(menuShowContacts);
                menuEdit.Click += StudentEnrollingEditButton_Click;
                menuAddPicture.Click += MenuAddStudentPicture_Click;
                menuPrint.Click += MenuPrintStudentEnrollingReceipt;
                menuShowPayments.Click += MenuShowPayments_Click;
                menuAddPayment.Click += MenuAddTuitionPayment_Click;
                menuPrintPaymentSummary.Click += MenuPrintPaymentSummary_Click;
                menuShowDiscounts.Click += MenuShowDiscounts_Click;
                menuAddDiscount.Click += MenuAddTuitionDiscount_Click;
                menuShowSubscriptions.Click += MenuShowSubscriptions_Click;
                menuAddSubscription.Click += MenuAddSubscription_Click;
                menuAddDiscipline.Click += MenuAddDiscipline_Click;
                menuShowDisciplines.Click += MenuShowDisciplines_Click;
                menuAddContact.Click += MenuAddContact_Click;
                menuShowContacts.Click += MenuShowContacts_Click;
                e.ContextMenu.Items.Add(new RadMenuSeparatorItem());
                e.ContextMenu.Items.Add(menuEdit);
                e.ContextMenu.Items.Add(menuPrint);
                e.ContextMenu.Items.Add(new RadMenuSeparatorItem());
                e.ContextMenu.Items.Add(menuAddPicture);
                e.ContextMenu.Items.Add(new RadMenuSeparatorItem());
                e.ContextMenu.Items.Add(menuSchoolFee);
                e.ContextMenu.Items.Add(new RadMenuSeparatorItem());
                e.ContextMenu.Items.Add(menuSubscription);
                e.ContextMenu.Items.Add(new RadMenuSeparatorItem());
                e.ContextMenu.Items.Add(menuDiscipline);
                e.ContextMenu.Items.Add(new RadMenuSeparatorItem());
                e.ContextMenu.Items.Add(menuContact);

            }


        }

        private void MenuAddTuitionPayment_Click(object sender, EventArgs e)
        {
            if (HomeGridView.CurrentRow.DataBoundItem is StudentEnrollingDTO enrollingDTO)
            {
                ShowAddTuitionPaymentForm(enrollingDTO.ConvertToStudentEnrolling());
            }
        }
        private void MenuAddTuitionDiscount_Click(object sender, EventArgs e)
        {
            if (HomeGridView.CurrentRow.DataBoundItem is StudentEnrollingDTO enrollingDTO)
            {
                ShowAddTuitionDiscountForm(enrollingDTO.ConvertToStudentEnrolling());
            }
        }
        private void MenuShowPayments_Click(object sender, EventArgs e)
        {
            if (HomeGridView.CurrentRow.DataBoundItem is StudentEnrollingDTO enrollingDTO)
            {
                ShowTuitionPaymentsForm(enrollingDTO);
            }
        }
        private void MenuShowDiscounts_Click(object sender, EventArgs e)
        {
            if (HomeGridView.CurrentRow.DataBoundItem is StudentEnrollingDTO enrollingDTO)
            {
                ShowTuitionDiscountsForm(enrollingDTO);
            }
        }
        private void MenuAddSubscription_Click(object sender, EventArgs e)
        {
            if (HomeGridView.CurrentRow.DataBoundItem is StudentEnrollingDTO enrollingDTO)
            {
                ShowAddSubscriptionForm(enrollingDTO.ConvertToStudentEnrolling());
            }
        }

        //impression du reçu d'inscription
        private void MenuPrintStudentEnrollingReceipt(object sender, EventArgs e)
        {
            if (HomeGridView.CurrentRow.DataBoundItem is StudentEnrollingDTO record)
            {

                record.SchoolYear = Program.SchoolYearList.FirstOrDefault(x => x.Id == record.SchoolYearId);
                var enrolling = record.ConvertToStudentEnrolling();
                var payments = cashFlowService.GetTuitionPaymentByEnrollingList(enrolling.Id).Result;
                enrolling.PaymentList = payments.Where(x => x.IsDuringEnrolling && x.Amount > 0).ToList();
                printService.PrintPaymentReceipt(enrolling, true);
            }
            //impression du reçu

        }
        //print summary of payments
        private void MenuPrintPaymentSummary_Click(object sender, EventArgs e)
        {
            if (HomeGridView.CurrentRow.DataBoundItem is StudentEnrollingDTO enrollingDTO)
            {
                var enrolling = enrollingDTO.ConvertToStudentEnrolling();
                enrolling.PaymentList = cashFlowService.GetTuitionPaymentByEnrollingList(enrolling.Id).Result;
                enrolling.SchoolYear = Program.CurrentSchoolYear;
                printService.PrintPaymentSummary(enrolling);
            }
        }
        #endregion

        #region Methodes  
        //affichage de UI pour l'ajout d'une réduction
        private void ShowAddTuitionDiscountForm(StudentEnrolling enrolling)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                var form = Program.ServiceProvider.GetService<AddTuitionDiscountForm>();
                form.Text = Language.labelAdd + ":.." + Language.labelDiscount;
                form.Icon = this.Icon;
                form.Init(enrolling);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    var cashFlowType = form.CashFlowTypeDropDownList.SelectedItem.DataBoundItem as CashFlowType;
                    var data = cashFlowService.GetTuitionDiscount(enrolling.Id, cashFlowType.Id).Result;
                    Program.TuitionDiscountList.Add(data);
                }
            }
            else
            {
                RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
        }

        // show ui tuition payment form
        private void ShowAddTuitionPaymentForm(StudentEnrolling enrolling)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                var form = Program.ServiceProvider.GetService<AddTuitionPaymentForm>();
                form.Text = Language.labelAdd + ":.." + Language.labelPayment;
                form.Icon = this.Icon;
                form.Init(enrolling);
                if (form.ShowDialog(this) == DialogResult.OK)
                {

                }
            }
            else
            {
                RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
            }

        }
        //affiche les versements d'un élève
        private void ShowTuitionPaymentsForm(StudentEnrollingDTO enrolling)
        {
            var form = Program.ServiceProvider.GetService<TuitionPaymentsForm>();
            form.Text = Language.labelPayments;
            form.Icon = this.Icon;
            form.Init(enrolling.ConvertToStudentEnrolling());
            form.Show();
        }
        //affiche les Réductions accordées à un élève
        private void ShowTuitionDiscountsForm(StudentEnrollingDTO enrolling)
        {
            var form = Program.ServiceProvider.GetService<TuitionDiscountsForm>();
            form.Text = Language.labelPayments;
            form.Icon = this.Icon;
            form.Init(enrolling.ConvertToStudentEnrolling());
            form.Show();
        }
        private void ShowUploadStudentPictureForm(StudentEnrollingDTO enrolling)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                var form = Program.ServiceProvider.GetService<UploadStudentPictureForm>();
                form.Icon = this.Icon;
                form.Init(enrolling.ConvertToStudentEnrolling());
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    enrolling.PictureUrl = form.UrlPicture;
                    studentEnrollingInfo.StudentLabel.Image = new Bitmap(Image.FromFile(enrolling.PictureUrl), new System.Drawing.Size(114, 114));
                }
            }
            else
            {
                RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
        }
        // show add ui subscription form
        private void ShowAddSubscriptionForm(StudentEnrolling enrolling)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                var form = Program.ServiceProvider.GetService<AddSubscriptionForm>();
                form.Text = Language.labelAdd + ":.." + Language.labelSubscription;
                form.Icon = this.Icon;
                form.Init(enrolling);
                if (form.ShowDialog(this) == DialogResult.OK)
                {

                }
            }
            else
            {
                RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
            }

        }
        // affiche les abonnements d'un élève
        private void ShowSubscriptionsForm(StudentEnrollingDTO enrolling)
        {
            var form = Program.ServiceProvider.GetService<SubscriptionsForm>();
            form.Text = enrolling.Student.FullName+": "+Language.labelSubscriptions;
            form.Icon = this.Icon;
            form.Init(enrolling.ConvertToStudentEnrolling());
            form.Show();
        }
        //create Home context menu for home main list view
        private void InitContextHomePage()
        {
            RadContextMenuManager contextMenuManager = new();
            RadContextMenu contextMenu = new();
            RadMenuItem menuEdit = new(Language.labelEdit);
            RadMenuItem menuPrint = new(Language.labelPrintRegistrationReceipt);
            RadMenuItem menuAddPicture = new RadMenuItem(Language.labelAddPicture);
            RadMenuItem menuSchoolFee = new(Language.labelSchoolingFee);
            RadMenuItem menuAddPayment = new(Language.labelAddPayment);
            RadMenuItem menuShowPayments = new(Language.labelShowPayments);
            RadMenuItem menuPrintPaymentSummary = new RadMenuItem(Language.labelPrintSummaryPayment);
            RadMenuItem menuShowDiscounts = new(Language.labelShowDiscounts);
            RadMenuItem menuAddDiscount = new(Language.labelAddDiscount);
            RadMenuItem menuSubscription = new(Language.labelSubscription);
            RadMenuItem menuAddSubscription = new(Language.labelAddSubscription);
            RadMenuItem menuShowSubscriptions = new(Language.labelShowSubscriptions);
            RadMenuItem menuDiscipline = new(Language.labelDiscipline);
            RadMenuItem menuAddDiscipline = new(Language.labelAddDiscipline);
            RadMenuItem menuShowDisciplines = new(Language.labelShowDiscipline);
            RadMenuItem menuContact = new(Language.labelContact);
            RadMenuItem menuAddContact = new(Language.labelAddContact);
            RadMenuItem menuShowContacts = new(Language.labelShowContact);
            menuEdit.Image = AppUtilities.GetImage("Edit");
            menuPrint.Image = AppUtilities.GetImage("Printer");
            menuAddPicture.Image = AppUtilities.GetImage("Add");
            menuAddPayment.Image = AppUtilities.GetImage("Add");
            menuShowPayments.Image = AppUtilities.GetImage("View");
            menuAddDiscount.Image = AppUtilities.GetImage("Add");
            menuShowDiscounts.Image = AppUtilities.GetImage("View");
            menuPrintPaymentSummary.Image = AppUtilities.GetImage("Printer");
            menuShowSubscriptions.Image = AppUtilities.GetImage("View");
            menuAddSubscription.Image = AppUtilities.GetImage("Add");
            menuAddDiscipline.Image = AppUtilities.GetImage("Add");
            menuShowDisciplines.Image = AppUtilities.GetImage("View");
            menuAddContact.Image = AppUtilities.GetImage("Add");
            menuShowContacts.Image = AppUtilities.GetImage("View");
            menuSchoolFee.Items.Add(menuAddPayment);
            menuSchoolFee.Items.Add(menuShowPayments);
            menuSchoolFee.Items.Add(menuPrintPaymentSummary);
            menuSchoolFee.Items.Add(new RadMenuSeparatorItem());
            menuSchoolFee.Items.Add(menuAddDiscount);
            menuSchoolFee.Items.Add(menuShowDiscounts);
            menuSubscription.Items.Add(menuAddSubscription);
            menuSubscription.Items.Add(menuShowSubscriptions);
            menuDiscipline.Items.Add(menuAddDiscipline);
            menuDiscipline.Items.Add(menuShowDisciplines);
            menuContact.Items.Add(menuAddContact);
            menuContact.Items.Add(menuShowContacts);
            menuEdit.Click += StudentEnrollingEditButton_Click;
            menuAddPicture.Click += MenuAddStudentPicture_Click;
            menuPrint.Click += MenuPrintStudentEnrollingReceipt;
            menuShowPayments.Click += MenuShowPayments_Click;
            menuAddPayment.Click += MenuAddTuitionPayment_Click;
            menuPrintPaymentSummary.Click += MenuPrintPaymentSummary_Click;
            menuShowDiscounts.Click += MenuShowDiscounts_Click;
            menuAddDiscount.Click += MenuAddTuitionDiscount_Click;
            menuShowSubscriptions.Click += MenuShowSubscriptions_Click;
            menuAddSubscription.Click += MenuAddSubscription_Click;
            menuAddDiscipline.Click += MenuAddDiscipline_Click;
            menuShowDisciplines.Click += MenuShowDisciplines_Click;
            menuAddContact.Click += MenuAddContact_Click;
            menuShowContacts.Click += MenuShowContacts_Click;
            contextMenu.Items.Add(menuEdit);
            contextMenu.Items.Add(menuPrint);
            contextMenu.Items.Add(new RadMenuSeparatorItem());
            contextMenu.Items.Add(menuAddPicture);
            contextMenu.Items.Add(new RadMenuSeparatorItem());
            contextMenu.Items.Add(menuSchoolFee);
            contextMenu.Items.Add(new RadMenuSeparatorItem());
            contextMenu.Items.Add(menuSubscription);
            contextMenu.Items.Add(new RadMenuSeparatorItem());
            contextMenu.Items.Add(menuDiscipline);
            contextMenu.Items.Add(new RadMenuSeparatorItem());
            contextMenu.Items.Add(menuContact);

            contextMenuManager.SetRadContextMenu(HomeMainListView, contextMenu);
        }

        private void MenuShowDisciplines_Click(object sender, EventArgs e)
        {
            if (this.HomeGridView.CurrentRow != null)
            {
                if (this.HomeGridView.CurrentRow.DataBoundItem is StudentEnrollingDTO enrollingDTO)
                {
                    var form = Program.ServiceProvider.GetService<DisciplinesForm>();
                    form.Text = enrollingDTO.Student.FullName + ": " + Language.labelDisciplinaryFile;
                    form.Icon = this.Icon;
                    form.Init(enrollingDTO.ConvertToStudentEnrolling());
                    form.Show();
                }
            }
        }

        private void MenuAddDiscipline_Click(object sender, EventArgs e)
        {
            if (this.HomeGridView.CurrentRow != null) {
                if (this.HomeGridView.CurrentRow.DataBoundItem is StudentEnrollingDTO enrollingDTO)
                {
                    var form = Program.ServiceProvider.GetService<AddDisciplineForm>();
                    form.Text = Language.labelAdd+":.. "+Language.labelDiscipline;
                    form.Icon = this.Icon;
                    form.Init(enrollingDTO.ConvertToStudentEnrolling());
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
           
                    }
                }
            }
        }

        private async void LoadBasicData()
        {
            var getSchoolYearList = schoolYearService.GetSchoolYearList();
            var getSchoolGroupList = schoolGroupService.GetSchoolGroupList();
            var getClassList = schoolClassService.GetSchoolClassList();
            var getRoomList = schoolRoomService.GetSchoolRoomList();
            var getCashflowTypeList = cashFlowTypeService.GetCashFlowTypeList();
            var getPaymenMeantList = paymentMeanService.GetPaymentMeanList();
            var getSchoolingCostList = schoolingCostService.GetSchoolingCostList();
            var getSubscripFeetionList = subscriptionFeeService.GetSubscriptionFeeList();
            var getSubjectGroupList = subjectGroupService.GetSubjectGroupList();
            var getSubjectList = subjectService.GetSubjectList();
            var getEvaluationSessionList = evaluationSessionService.GetEvaluationSessionList();
            var getRatingSystemList = ratingSystemService.GetRatingSystemList();
            var getJobList = jobService.GetJobList();
            var getEmployeeGroupList = employeeGroupService.GetEmployeeGroupList();
            var getModuleList = moduleService.GetModuleList();
            var getUserList = userService.GetUserList();
            var getEmployeeList = employeeService.GetEmployeeList();
            var getCountryList = countryService.GetCountryList();
            var getDisciplineSubjectList = disciplineService.GetDisciplineSubjectList();
            Program.SchoolYearList = await getSchoolYearList;
            Program.SchoolGroupList = await getSchoolGroupList;
            Program.SchoolClassList = await getClassList;
            Program.SchoolRoomList = await getRoomList;
            Program.CashFlowTypeList = await getCashflowTypeList;
            Program.PaymentMeanList = await getPaymenMeantList;
            Program.SchoolingCostList = await getSchoolingCostList;
            Program.SubscriptionFeeList = await getSubscripFeetionList;
            Program.SubjectGroupList = await getSubjectGroupList;
            Program.SubjectList = await getSubjectList;
            Program.EvaluationSessionList = await getEvaluationSessionList;
            Program.RatingSystemList = await getRatingSystemList;
            Program.JobList = await getJobList;
            Program.EmployeeGroupList = await getEmployeeGroupList;
            Program.UserList = await getUserList;
            Program.EmployeeList = await getEmployeeList;
            Program.ModuleList = await getModuleList;
            Program.CountryList = await getCountryList;
            Program.DisciplineSubjectList=await getDisciplineSubjectList;
            //sépare les sessions d'évaluation en mère-fille
            SplitEvaluationSessionList();
            isFirstLoadingBasicData = true;
            PopulateSchoolYearOnDropDownList();
        }
        // se deconnecter du système
        private void LogOut()
        {

            DialogResult dialogResult = RadMessageBox.Show("Voulez-vous vous déconnecter de l'application ?", "Déconnexion de l'application", MessageBoxButtons.YesNo, RadMessageIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                isLogOut = true;
                this.Close();
                Application.OpenForms["LoginForm"].Show();

            }

        }
        //load school year on dropDownList
        private void PopulateSchoolYearOnDropDownList()
        {
            HomeSchoolYearDropDownList.DataSource = Program.SchoolYearList;
            HomeSchoolYearDropDownList.DisplayMember = "Name";
            HomeSchoolYearDropDownList.ValueMember = "Id";

            CashFlowSchoolYearDropDownList.DataSource = Program.SchoolYearList;
            CashFlowSchoolYearDropDownList.DisplayMember = "Name";
            CashFlowSchoolYearDropDownList.ValueMember = "Id";

            TimeTableSchoolYearDropDownList.DataSource = Program.SchoolYearList;
            TimeTableSchoolYearDropDownList.DisplayMember = "Name";
            TimeTableSchoolYearDropDownList.ValueMember = "Id";

            DisciplineSchoolYearDropDownList.DataSource = Program.SchoolYearList;
            DisciplineSchoolYearDropDownList.DisplayMember = "Name";
            DisciplineSchoolYearDropDownList.ValueMember = "Id";

            StudentNoteSchoolYearDropDownList.DataSource = Program.SchoolYearList;
            StudentNoteSchoolYearDropDownList.DisplayMember = "Name";
            StudentNoteSchoolYearDropDownList.ValueMember = "Id";

            ReportSchoolYearDropDownList.DataSource = Program.SchoolYearList;
            ReportSchoolYearDropDownList.DisplayMember = "Name";
            ReportSchoolYearDropDownList.ValueMember = "Id";

            EmployeeSchoolYearDropDownList.DataSource = Program.SchoolYearList;
            EmployeeSchoolYearDropDownList.DisplayMember = "Name";
            EmployeeSchoolYearDropDownList.ValueMember = "Id";

            if (Program.SchoolYearList.Any())
            {
                var openYear = GetOpenSchoolYear();
                if (openYear.Id != 0)
                {
                    HomeSchoolYearDropDownList.SelectedValue = openYear.Id;
                    CashFlowSchoolYearDropDownList.SelectedValue = openYear.Id;
                    TimeTableSchoolYearDropDownList.SelectedValue = openYear.Id;
                    DisciplineSchoolYearDropDownList.SelectedValue = openYear.Id;
                    StudentNoteSchoolYearDropDownList.SelectedValue = openYear.Id;
                    ReportSchoolYearDropDownList.SelectedValue = openYear.Id;
                    EmployeeSchoolYearDropDownList.SelectedValue = openYear.Id;
                    Program.CurrentSchoolYear = openYear;
                }
                else
                {
                    Program.CurrentSchoolYear = Program.SchoolYearList.OrderByDescending(x => x.Id).FirstOrDefault();
                }
            }

        }
        //return open year 
        private SchoolYear GetOpenSchoolYear()
        {
            var openYearList = Program.SchoolYearList.Where(y => y.IsClosed == false);
            return openYearList.Any() ? openYearList.FirstOrDefault() : new SchoolYear();
        }
        //ajoute les types de flux de trésorerie dans l'objet homeLeftListView
        private void LoadCashFlowTypeListToHomeLeftView()
        {
            if (HomeSchoolYearDropDownList.SelectedItem != null)
            {
                if (HomeSchoolYearDropDownList.SelectedItem.DataBoundItem is SchoolYear schoolYear)
                {
                    var listItemToAdd = Program.SchoolingCostList.Where(x => x.IsPayable == true && x.SchoolYearId == schoolYear.Id).Select(x => x.CashFlowType).Distinct().OrderBy(x=>x.Sequence).ToList();
                    var insolvencyGoup = HomeLeftListView.Groups.Where(x => (int)x.Key == 4).FirstOrDefault();
                    var solvencyGoup = HomeLeftListView.Groups.Where(x => (int)x.Key == 5).FirstOrDefault();
                    if (insolvencyGoup != null)
                    {
                        //delete old insolvency item
                        var insolvencyOldItem = HomeLeftListView.Items.Where(x => x.Group.Key == insolvencyGoup.Key);
                        foreach (var item in insolvencyOldItem.Clone())
                        {
                            HomeLeftListView.Items.Remove(item);

                        }
                    }
                    if (solvencyGoup != null)
                    {
                        //delete old solvency item
                        var solvencyOldItem = HomeLeftListView.Items.Where(x => x.Group.Key == solvencyGoup.Key);

                        foreach (var item in solvencyOldItem.Clone())
                        {
                            HomeLeftListView.Items.Remove(item);
                        }
                    }
                    //add new item
                    foreach (var item in listItemToAdd)
                    {
                        if (insolvencyGoup != null)
                        {
                            ListViewDataItem dataItem = new()
                            {
                                Key = item.Id,
                                Value = item.Name,
                                Tag = item.Name,
                                CheckState = ToggleState.On,
                                Text = item.Name.Trim().Length > 20 ? item.Name.Substring(0, 20) + "..." : item.Name,
                                Group = insolvencyGoup
                            };
                            HomeLeftListView.Items.Add(dataItem);
                        }
                        if (solvencyGoup != null)
                        {
                            ListViewDataItem dataItem = new()
                            {
                                Key = item.Id,
                                Value = item.Name,
                                Tag = item.Name,
                                CheckState = ToggleState.On,
                                Text = item.Name.Trim().Length > 20 ? item.Name.Substring(0, 20) + "..." : item.Name,
                                Group = solvencyGoup
                            };
                            HomeLeftListView.Items.Add(dataItem);
                        }
                    }
                }
            }

        }
        //load basic data list to left listview of home page
        private void LoadDataToHomeLeftListView()
        {
            //liste des salles de classe
            var roomList = new List<SchoolRoom>();
            //liste des classes
            var classList = new List<SchoolClass>();
            //liste des groupes de classe
            var groupList = new List<SchoolGroup>();
            if (clientApp.UserConnected.UserName != "root")
            {
                roomList = clientApp.UserConnected.Rooms.Select(x => x.Room).ToList();
                //get class list for other user
                var classIdList = roomList.Select(x => x.ClassId).ToList();
                foreach (var itemClass in Program.SchoolClassList)
                {
                    if (classIdList.Contains(itemClass.Id))
                    {
                        classList.Add(itemClass);
                    }
                }
                //get class group for the other user
                var groupIdList = classList.Select(x => x.GroupId).ToList();
                foreach (var group in Program.SchoolGroupList)
                {
                    if (groupIdList.Contains(group.Id))
                    {
                        groupList.Add(group);
                    }
                }
            }
            else
            {
                roomList = Program.SchoolRoomList.ToList();
                classList = Program.SchoolClassList.ToList();
                groupList = Program.SchoolGroupList.ToList();
            }
            //clear
            HomeLeftListView.Items.Clear();
            ListViewDataItemGroup homeGroupSudentGroup = new()
            {
                Key = 1,
                Text = Language.labelStudentsByGroup.ToUpper()
            };
            ListViewDataItemGroup homeClassStudentGroup = new()
            {
                Key = 2,
                Text = Language.labelStudentsByClass.ToUpper()
            };
            ListViewDataItemGroup homeTuitionFeeStatusdGroup = new()
            {
                Key = 3,
                Text = Language.labelTuitionFees.ToUpper()
            };
            ListViewDataItemGroup homeInsolvencyStatusdGroup = new()
            {
                Key = 4,
                Text = Language.labelInsolvency.ToUpper()
            };
            ListViewDataItemGroup homeSolvencyStatusdGroup = new()
            {
                Key = 5,
                Text = Language.labelSolvency.ToUpper()
            };
            ListViewDataItemGroup homeHealthStatusdGroup = new()
            {
                Key = 6,
                Text = Language.labelHealthStatus.ToUpper()
            };
            ListViewDataItemGroup homeStudentStatusdGroup = new()
            {
                Key = 7,
                Text = Language.labelStudentsByStatus.ToUpper()
            };
            HomeLeftListView.Groups.AddRange(new ListViewDataItemGroup[] { homeGroupSudentGroup, homeClassStudentGroup, homeTuitionFeeStatusdGroup, homeInsolvencyStatusdGroup, homeSolvencyStatusdGroup, homeHealthStatusdGroup, homeStudentStatusdGroup });
            //add group list
            foreach (var item in groupList)
            {
                ListViewDataItem dataItem = new()
                {
                    Key = item.Id,
                    Value = item.Name,
                    Tag = item,
                    CheckState = ToggleState.On,
                    Text = item.Name.Trim().Length > 20 ? item.Name.Substring(0, 20) + "..." : item.Name,
                    Group = homeGroupSudentGroup
                };
                HomeLeftListView.Items.Add(dataItem);
            }
            //add class list
            foreach (var item in classList)
            {
                ListViewDataItem dataItem = new()
                {
                    Key = item.Id,
                    Value = item.Name,
                    Tag = item,
                    CheckState = ToggleState.On,
                    Text = item.Name.Trim().Length > 20 ? item.Name.Substring(0, 20) + "..." : item.Name,
                    Group = homeClassStudentGroup
                };
                HomeLeftListView.Items.Add(dataItem);
            }
            // add cashflow type for insolvable and solvable
            LoadCashFlowTypeListToHomeLeftView();

            //ETAT des versements           
            ListViewDataItem itemPaid = new()
            {
                Text = Language.labelPaid,
                Key = 0,
                CheckState = ToggleState.On,
                Group = homeTuitionFeeStatusdGroup
            };
            HomeLeftListView.Items.Add(itemPaid);
            // effectif des versements impayés
            ListViewDataItem itemUnPaid = new()
            {
                Text = Language.labelUnPaid,
                Key = 1,
                CheckState = ToggleState.On,
                Group = homeTuitionFeeStatusdGroup
            };
            HomeLeftListView.Items.Add(itemUnPaid);

            //etat de sante
            // itemHealthGood.Text = "Good";
            ListViewDataItem itemHealthGood = new()
            {
                Key = 0,
                Image = Resources.heartbeat_green,
                CheckState = ToggleState.On,
                Group = homeHealthStatusdGroup
            };
            HomeLeftListView.Items.Add(itemHealthGood);
            //itemHealthMedium.Text = "Medium";
            ListViewDataItem itemHealthMedium = new()
            {
                Key = 1,
                Image = Resources.heartbeat_orange,
                CheckState = ToggleState.On,
                Group = homeHealthStatusdGroup
            };
            HomeLeftListView.Items.Add(itemHealthMedium);
            //itemHealthBad.Text = "Bad";
            ListViewDataItem itemHealthBad = new()
            {
                Key = 2,
                Image = Resources.heartbeat_red,
                CheckState = ToggleState.On,
                Group = homeHealthStatusdGroup
            };
            HomeLeftListView.Items.Add(itemHealthBad);
            // effectif des élèves actifs
            ListViewDataItem itemStatusIn = new()
            {
                Text = Language.labelStudentLeft,
                Key = 1,
                CheckState = ToggleState.On,
                Group = homeStudentStatusdGroup
            };
            HomeLeftListView.Items.Add(itemStatusIn);
            //effectif des élèves partis au cours de l'année
            ListViewDataItem itemStatusOut = new()
            {
                Text = Language.labelStudentsNoLeft,
                Key = 0,
                CheckState = ToggleState.Off,
                Group = homeStudentStatusdGroup
            };
            HomeLeftListView.Items.Add(itemStatusOut);
        }
        //load enrolling of students
        private async void LoadEnrollingStudentList()
        {
            HomeInfoRightPanel.Visible = false;
            if (HomeSchoolYearDropDownList.SelectedItem != null)
            {
                if (HomeSchoolYearDropDownList.SelectedItem.DataBoundItem is SchoolYear record)
                {
                    //lancement des tâches d'extraction des données
                    var getPaymentListTask = cashFlowService.GetTuitionPaymentBySchoolYearList(record.Id);
                    var getEnrollingListTask = studentEnrollingService.GetStudentEnrollingListAsync(record.Id);
                    var getDiscountListTask = cashFlowService.GetTuitionDiscountBySchoolYearList(record.Id);
                    var getSchoolingCostItemTask = schoolingCostService.GetSchoolingCostItemsBySchoolYear(record.Id);
                    //on s'assure que toutes soient terminées
                    await System.Threading.Tasks.Task.WhenAll(getPaymentListTask, getEnrollingListTask, getDiscountListTask);
                    //chargement des données dans les listes principales
                    Program.TuitionDiscountList = getDiscountListTask.Result;
                    Program.TuitionPaymentList = getPaymentListTask.Result;
                    Program.SchoolingCostItemList = getSchoolingCostItemTask.Result;
                    var enrollingList = getEnrollingListTask.Result;
                    //Création de la liste des inscriptions à afficher
                    Program.StudentEnrollingList = new List<StudentEnrollingDTO>();
                    foreach (var enrolling in enrollingList)
                    {
                        enrolling.SchoolClass.Group = Program.SchoolClassList.Where(x => x.Id == enrolling.ClassId).Select(x => x.Group).FirstOrDefault();
                        //convertion du l'inscription extraite à l'inscription à afficher
                        var enrollingDTO = enrolling.ConvertToStudentEnrollingDTO();
                        //extraction de la liste des frais exigibles
                        var feeIdList = Program.SchoolingCostList.Where(x => x.SchoolYearId == Program.CurrentSchoolYear.Id && x.IsPayable == true && x.SchoolClassId == enrolling.ClassId).Select(x => x.CashFlowTypeId).ToList();
                        //extraction des réductions et des versements de l'élève
                        enrollingDTO.PaymentList = Program.TuitionPaymentList.Where(x => x.EnrollingId == enrolling.Id).ToList();
                        enrollingDTO.PaymentPayableList = Program.TuitionPaymentList.Where(x => x.EnrollingId == enrolling.Id && feeIdList.Contains(x.CashFlowTypeId)).ToList();
                        enrollingDTO.DiscountList = Program.TuitionDiscountList.Where(x => x.EnrollingId == enrolling.Id && feeIdList.Contains(x.CashFlowTypeId)).ToList();
                        //extraction de la somme des frais exigibles
                        var amountFee = Program.SchoolingCostList.Where(x => x.SchoolYearId == Program.CurrentSchoolYear.Id && x.IsPayable == true && x.SchoolClassId == enrolling.ClassId).Sum(x => x.Amount);
                        //calcul des impayés de l'élève
                        enrollingDTO.Balance = amountFee - (enrollingDTO.DiscountList.Sum(x => x.Amount) + enrollingDTO.PaymentPayableList.Sum(x => x.Amount));
                        //récupération de l'état des insolvabilités
                        foreach(int feeId in feeIdList)
                        {
                            InsolvencyState state= new() { 
                                Id = feeId,
                                Amount = localEnrollingService.GetInsolvencyAmount(enrollingDTO,feeId),
                            };
                            state.Value = state.Amount > 0;
                            enrollingDTO.InsolvencyStateList.Add(state);
                        }
                        
                        // Ajout de l'inscription dans la liste à afficher
                        Program.StudentEnrollingList.Add(enrollingDTO);
                    }

                    HomeGridView.DataSource = Program.StudentEnrollingList;
                    HomeMainListView.DataSource = Program.StudentEnrollingList;
                    HomeLeftListView.ListViewElement.SynchronizeVisualItems();
                    HomeMainListView.ListViewElement.SynchronizeVisualItems();

                }
            }
        }
        
        // initialisation du grid view employé
        private void InitGridViewHomePage()
        {
            HomeGridView.ReadOnly = true;
            HomeGridView.MasterTemplate.EnableFiltering = true;
            HomeGridView.EnableFiltering = true;
            HomeGridView.EnableCustomFiltering = true;
            HomeGridView.ShowFilteringRow = false;
            HomeGridView.AllowAddNewRow = false;
            HomeGridView.AutoGenerateColumns = false;
            HomeGridView.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            GridViewTextBoxColumn idNumberColumn = new("Student.IdNumber");
            GridViewTextBoxColumn studentColumn = new("Student.FullName");
            GridViewTextBoxColumn classColumn = new("ClassName");
            GridViewImageColumn healtImageColumn = new("HealthImage");
            GridViewDecimalColumn balanceColumn = new("Balance");
            GridViewTextBoxColumn groupColumn = new("ClassGroupName");
            GridViewTextBoxColumn healthColumn = new("Student.Health");
            groupColumn.IsVisible = false;
            healthColumn.IsVisible = false;
            idNumberColumn.HeaderText = Language.labelStudentId;
            studentColumn.HeaderText = Language.labelStudent;
            classColumn.HeaderText = Language.labelClass;
            healtImageColumn.HeaderText = Language.labelHealth;
            healthColumn.HeaderText = Language.labelHealth;
            groupColumn.HeaderText = Language.labelGroup;
            balanceColumn.HeaderText = Language.labelUnPaid;
            idNumberColumn.Width = 100;
            studentColumn.Width = 250;
            classColumn.Width = 200;
            healtImageColumn.Width = 100;

            HomeGridView.Columns.Add(idNumberColumn);
            HomeGridView.Columns.Add(studentColumn);
            HomeGridView.Columns.Add(classColumn);
            HomeGridView.Columns.Add(healtImageColumn);
            HomeGridView.Columns.Add(balanceColumn);
            HomeGridView.Columns.Add(groupColumn);
            HomeGridView.Columns.Add(healthColumn);
            GridViewSummaryRowItem total = new()
            {
                new GridViewSummaryItem("Student.IdNumber", " {0}", GridAggregateFunction.Count),
                new GridViewSummaryItem("Balance", " {0}", GridAggregateFunction.Sum)
            };
            HomeGridView.MasterTemplate.SummaryRowsBottom.Add(total);
            foreach (GridViewDataColumn col in this.HomeGridView.Columns)
            {
                col.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            }
        }
        private void InitHomeMainListView()
        {
            GroupDescriptor groupByValue = new GroupDescriptor(new SortDescriptor[]
        {
                new SortDescriptor("ClassName", ListSortDirection.Ascending)
        });

            HomeMainListView.GroupDescriptors.Add(groupByValue);
        }

        //initialisation des contrôles utilisateurs personnalisés 
        private void InitHomePageCustomControls()
        {
            HomeInfoRightPanel.Visible = false;
            studentEnrollingInfo = new StudentEnrollingInfo()
            {
                Dock = DockStyle.Fill,
                Location = new System.Drawing.Point(0, 0),
                Margin = new Padding(2, 2, 2, 2)
            };

            studentEnrollingInfo.CloseButton.Click += delegate (object sender, EventArgs e)
            {
                HomeInfoRightPanel.Visible = false;
            };
            studentEnrollingInfo.EditButton.Click += StudentEnrollingEditButton_Click;
            studentEnrollingInfo.ContactsLabel.DoubleClick += MenuShowContacts_Click;
            studentEnrollingInfo.HealthFileLabel.DoubleClick += MenuShowHealthFile_Click;
            studentEnrollingInfo.SubscriptionsLabel.DoubleClick += MenuShowSubscriptions_Click;
            studentEnrollingInfo.DisciplineFileLabel.DoubleClick += MenuShowDisciplines_Click;
            HomeInfoRightPanel.Controls.Add(studentEnrollingInfo);
        }

        //affiche les informations d'une inscription
        private void LoadSelectedStudentEnrollingDetail(DTO.StudentEnrollingDTO record)
        {
            var getRoom = studentEnrollingService.GetStudentRoomAsync(record.StudentId, record.SchoolYearId);
            var getSubscriptions = subscriptionService.GetSubscriptionListByEnrollingAsync(record.Id);
            var getDisciplines = disciplineService.GetDisciplineListByEnrolling(record.Id);
            var getContacts = contactService.GetContactList(record.StudentId);
            HomeInfoRightPanel.Visible = true;
            studentEnrollingInfo.StudentTextBox.Text = record.Student.FullName;
            studentEnrollingInfo.EnrollingDateTextBox.Text = record.Date.ToString("dd/MM/yyyy");
            studentEnrollingInfo.BirthDayTextBox.Text = record.Student.BirthDate.ToString("dd/MM/yyyy");
            studentEnrollingInfo.BirthPlaceTextBox.Text = record.Student.BirthPlace;
            studentEnrollingInfo.IdCardTextBox.Text = record.Student.IdCard;
            studentEnrollingInfo.PhoneTextBox.Text = record.Student.Phone;
            studentEnrollingInfo.EmailTextBox.Text = record.Student.Email;
            studentEnrollingInfo.AddressTextBox.Text = record.Student.Address;
            studentEnrollingInfo.NationalityTextBox.Text = record.Student.Nationality;
            studentEnrollingInfo.SexTextBox.Text = record.Student.Sex;
            studentEnrollingInfo.EditButton.Image = AppUtilities.GetImage("Edit");
            studentEnrollingInfo.CloseButton.Image = AppUtilities.GetImage("Close");
            //affichage photo 
            if (File.Exists(record.PictureUrl))
            {
                studentEnrollingInfo.StudentLabel.Image = new Bitmap(Image.FromFile(record.PictureUrl), new System.Drawing.Size(114, 114));
            }
            else
            {
                if (File.Exists(record.Student.PictureUrl))
                {
                    studentEnrollingInfo.StudentLabel.Image = new Bitmap(Image.FromFile(record.Student.PictureUrl), new System.Drawing.Size(114, 114));
                }
                else
                {
                    //on cherche une photo dans le dossier 
                    var url = clientApp.StudentPitureFolder + "/" + record.Student.IdNumber;
                    if (File.Exists(url))
                    {
                        studentEnrollingInfo.StudentLabel.Image = new Bitmap(Image.FromFile(url), new System.Drawing.Size(114, 114));
                    }
                    else
                    {
                        using var ms = new MemoryStream(Resources.no_image);
                        studentEnrollingInfo.StudentLabel.Image = Image.FromStream(ms);
                    }
                }

            }
            studentEnrollingInfo.RoomTextBox.Text = getRoom.Result.Room.Name;
            studentEnrollingInfo.ContactsLabel.Text = $"{Language.labelContacts}: {getContacts.Result.Count}";
            studentEnrollingInfo.DisciplineFileLabel.Text = $"{Language.labelDisciplinaryFile}: {getDisciplines.Result.Count}";
            studentEnrollingInfo.HealthFileLabel.Text = $"{Language.labelMedicalFile}: 0";
            studentEnrollingInfo.SubscriptionsLabel.Text = $"{Language.labelSubscriptions}: {getSubscriptions.Result.Count}";
            studentEnrollingInfo.Visible = true;
        }
        // permet de filtrer l'object homeMainListView en fonction des item décochés sur le leftlistview
        private async void UpdateHomeMainListView()
        {
            foreach (ListViewDataItem item in HomeMainListView.Items)
            {
                var record = item.DataBoundItem as DTO.StudentEnrollingDTO;
                bool isRecordItemVisible = true;
                foreach (ListViewDataItem leftViewItem in HomeLeftListView.Items)
                {

                    if (leftViewItem.Group.Text.ToUpper() == Language.labelStudentsByGroup.ToUpper())
                    {
                        var itemGroup = Program.SchoolGroupList.FirstOrDefault(x => x.Id == (int)leftViewItem.Key);
                        if (itemGroup != null)
                        {
                            if (record.ClassGroupName.ToUpper() == itemGroup.Name.ToUpper() && leftViewItem.CheckState == ToggleState.Off)
                            {
                                isRecordItemVisible = false;
                                break;
                            }
                        }
                    }
                    if (leftViewItem.Group.Text.ToUpper() == Language.labelStudentsByClass.ToUpper())
                    {
                        var itemClass = Program.SchoolClassList.FirstOrDefault(x => x.Id == (int)leftViewItem.Key);
                        if (itemClass != null)
                        {
                            if (record.ClassName.ToUpper() == itemClass.Name.ToUpper() && leftViewItem.CheckState == ToggleState.Off)
                            {
                                isRecordItemVisible = false;
                                break;
                            }
                        }
                    }
                    if (leftViewItem.Group.Text.ToUpper() == Language.labelHealthStatus.ToUpper())
                    {
                        switch ((int)leftViewItem.Key)
                        {
                            case 0:
                                if (leftViewItem.CheckState == ToggleState.Off && record.Student.Health == 0)
                                    isRecordItemVisible = false;
                                break;
                            case 1:
                                if (leftViewItem.CheckState == ToggleState.Off && record.Student.Health == 1)
                                    isRecordItemVisible = false;
                                break;
                            case 2:
                                if (leftViewItem.CheckState == ToggleState.Off && record.Student.Health == 2)
                                    isRecordItemVisible = false;
                                break;
                        }
                    }
                    if (leftViewItem.Group.Text.ToUpper() == Language.labelStudentsByStatus.ToUpper())
                    {
                        bool state = true;
                        if ((int)leftViewItem.Key == 0) state = false;
                        if (record.IsActive == state && leftViewItem.CheckState == ToggleState.Off)
                        {
                            isRecordItemVisible = false;
                            break;
                        }
                    }
                    if (leftViewItem.Group.Text.ToUpper() == Language.labelTuitionFees.ToUpper())
                    {
                        isRecordItemVisible = true;
                        int val = record.Balance > 0 ? 1 : 0;
                        if ((int)leftViewItem.Key == val && leftViewItem.CheckState == ToggleState.Off)
                        {
                            isRecordItemVisible = false;
                            break;
                        }
                    }

                    if (leftViewItem.Group.Text.ToUpper() == Language.labelSolvency.ToUpper())
                    {
                        isRecordItemVisible = true;
                        if (record.InsolvencyStateList.Where(c => c.Id == (int)leftViewItem.Key && c.Value == false).Count() == 1)
                        {
                            if (leftViewItem.CheckState == ToggleState.Off)
                            {
                                isRecordItemVisible = false;
                                break;
                            }
                        }
                    }
                    if (leftViewItem.Group.Text.ToUpper() == Language.labelInsolvency.ToUpper())
                    {
                        isRecordItemVisible = true;
                        if (record.InsolvencyStateList.Where(c => c.Id == (int)leftViewItem.Key && c.Value == true).Count() == 1)
                        {
                            if (leftViewItem.CheckState == ToggleState.Off)
                            {
                                isRecordItemVisible = false;
                                break;
                            }
                        }
                    }
                }
                if (isRecordItemVisible == false)
                {
                    item.Visible = false;
                }
                else
                {
                    item.Visible = true;
                }
            }
            await System.Threading.Tasks.Task.Delay(0);
        }
        //permet de filtrer l'object homeMainListView en fonction des recherches
        private bool FilterHomePredicate(ListViewDataItem item)
        {
            
            if (HomeSearchTextBox.Text != string.Empty)
            {
                var record = item.DataBoundItem as DTO.StudentEnrollingDTO;
                if (record.Student.FullName.ToLower().Contains(HomeSearchTextBox.Text.ToLower()))
                {
                    return true;
                }
                if (record.ClassName.ToLower().Contains(HomeSearchTextBox.Text.ToLower()))
                {
                    return true;
                }
                if (record.Student.IdNumber.ToLower().Contains(HomeSearchTextBox.Text.ToLower()))
                {
                    return true;
                }
                return false;
            }
            return true;
        }
        //permet de filter par status de payement: impayé ou payé
        private bool IsStatusPaymentChecked(StudentEnrollingDTO enrolling)
        {
            bool status = true;
            int val = enrolling.Balance == 0 ? 0 : 1;
            foreach (ListViewDataItem item in HomeLeftListView.Items)
            {
                if (item.Group.Text.ToUpper() == Language.labelTuitionFees.ToUpper())
                {
                    if ((int)item.Key == val && item.CheckState == ToggleState.Off)
                    {
                        status = false;
                    }
                }
            }
            return status;
        }
        //permet de filter par status de santé
        private bool IsStatusHealthChecked(string healthStatus)
        {
            bool status = true;
            foreach (ListViewDataItem item in HomeLeftListView.Items)
            {
                if (item.Key.ToString() == healthStatus && item.Group.Text == Language.labelHealthStatus.ToUpper())
                {
                    if (item.CheckState == ToggleState.Off)
                    {
                        status = false;
                        break;
                    }
                }

            }
            return status;
        }
        //permet de filter les élèves insolvables
        private bool IsStatusInsolvencyChecked(DTO.StudentEnrollingDTO enrolling)
        {
            bool status = true;

            foreach (ListViewDataItem item in HomeLeftListView.Items)
            {
                if (item.Group.Text.ToUpper() == Language.labelInsolvency.ToUpper())
                {
                    if (enrolling.InsolvencyStateList.Where(c => c.Id == (int)item.Key && c.Value == true).Count() == 1)
                    {
                        if (item.CheckState == ToggleState.Off)
                        {
                            status = false;
                            break;
                        }
                    }
                }
            }
            return status;
        }
        //permet de filter les élèves solvables
        private bool IsStatusSolvencyChecked(DTO.StudentEnrollingDTO enrolling)
        {
            bool status = true;

            foreach (ListViewDataItem item in HomeLeftListView.Items)
            {

                if (item.Group.Text.ToUpper() == Language.labelSolvency.ToUpper())
                {
                    if (enrolling.InsolvencyStateList.Where(c => c.Id == (int)item.Key && c.Value == false).Count() == 1)
                    {
                        if (item.CheckState == ToggleState.Off)
                        {
                            status = false;
                            break;
                        }
                    }
                }
            }
            return status;
        }
        //permet de filter les élèves par group de classe
        private bool IsStudentByGroupChecked(string statusGroup)
        {
            bool status = true;
            foreach (ListViewDataItem item in HomeLeftListView.Items)
            {

                if (item.Value != null)
                {
                    if (item.Group.Text.ToUpper() == Language.labelStudentsByGroup.ToUpper())
                    {
                        var itemGroup = Program.SchoolGroupList.FirstOrDefault(x => x.Id == (int)item.Key);
                        if (itemGroup != null)
                        {
                            if (itemGroup.Name.ToUpper() == statusGroup.ToUpper())
                            {

                                if (item.CheckState == ToggleState.Off)
                                {
                                    status = false;
                                    break;
                                }
                            }
                        }
                    }
                }

            }
            return status;
        }
        //permet de filter les élèves par classe
        private bool IsStudentByClassChecked(string statusClass)
        {
            bool status = true;

            foreach (ListViewDataItem item in HomeLeftListView.Items)
            {

                if (item.Value != null)
                {
                    if (item.Group.Text.ToUpper() == Language.labelStudentsByClass.ToUpper())
                    {
                        var itemClass = Program.SchoolClassList.FirstOrDefault(x => x.Id == (int)item.Key);
                        if (itemClass != null)
                        {
                            if (itemClass.Name.ToUpper() == statusClass.ToUpper())
                            {

                                if (item.CheckState == ToggleState.Off)
                                {
                                    status = false;
                                    break;
                                }
                            }
                        }
                    }
                }

            }

            return status;
        }
        //permet de filter les élèves par statut: parti au cours de l'année ou pas
        private bool IsStudentStatusChecked(DTO.StudentEnrollingDTO enrolling)
        {
            bool status = true;
            int val = enrolling.IsActive ? 1 : 0;
            foreach (ListViewDataItem item in HomeLeftListView.Items)
            {
                if (item.Group.Text.ToUpper() == Language.labelStudentsByStatus.ToUpper())
                {
                    if ((int)item.Key == val && item.CheckState == ToggleState.Off)
                    {
                        status = false;
                        break;
                    }
                }

            }
            return status;
        }

        // show ui to add student enrolling
        private void ShowAddStudentEnrollingForm()
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                var form = Program.ServiceProvider.GetService<AddStudentEnrollingForm>();
                form.Text = Language.labelAdd + ":.. " + Language.labelRegistration;
                form.Icon = this.Icon;
                form.Init(Program.CurrentSchoolYear);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    var data = studentEnrollingService.GetStudentEnrollingAsync((form.StudentDropDownList.SelectedItem.DataBoundItem as Student).Id, Program.CurrentSchoolYear.Id).Result;
                    Program.StudentEnrollingList.Add(data.ConvertToStudentEnrollingDTO());
                    HomeGridView.DataSource = new List<DTO.StudentEnrollingDTO>();
                    HomeMainListView.DataSource = new List<DTO.StudentEnrollingDTO>();
                    HomeGridView.DataSource = Program.StudentEnrollingList;
                    HomeMainListView.DataSource = Program.StudentEnrollingList;
                }
            }
            else
            {
                RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);

            }

        }
        private void ShowEditStudentEnrollingForm(DTO.StudentEnrollingDTO enrollingDTO)
        {
            if (!Program.CurrentSchoolYear.IsClosed)
            {
                enrollingDTO.SchoolYear = Program.CurrentSchoolYear;
                var form = Program.ServiceProvider.GetService<EditStudentEnrollingForm>();
                form.Text = Language.labelUpdate + ":.. " + Language.labelEnroll;
                form.Icon = this.Icon;
                form.Init(enrollingDTO.ConvertToStudentEnrolling());
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    var data = studentEnrollingService.GetStudentEnrollingAsync((form.StudentDropDownList.SelectedItem.DataBoundItem as Student).Id, Program.CurrentSchoolYear.Id).Result;
                    enrollingDTO = data.ConvertToStudentEnrollingDTO();
                    HomeGridView.DataSource = new List<StudentEnrollingDTO>();
                    HomeGridView.DataSource = Program.StudentEnrollingList;
                    HomeMainListView.DataSource = Program.StudentEnrollingList;
                }
            }
            else
            {
                RadMessageBox.Show(this, Language.messageNoActionWithClosedYear, "", MessageBoxButtons.OK, RadMessageIcon.Info);
            }

        }
        #endregion

    }
}
