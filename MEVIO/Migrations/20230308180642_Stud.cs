using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MEVIO.Migrations
{
    /// <inheritdoc />
    public partial class Stud : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EducationForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EducationFormName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationForms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlaceForMeasures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaceForMeasureName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFree = table.Column<bool>(type: "bit", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceForMeasures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requisites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OKPO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckingAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MFO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalSumForEducation = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requisites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeasonOfBeginning",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeasonName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeasonOfBeginning", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserChats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserChatName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserChats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeasuresBusyTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Begin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlaceForMeasureId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasuresBusyTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeasuresBusyTable_PlaceForMeasures_PlaceForMeasureId",
                        column: x => x.PlaceForMeasureId,
                        principalTable: "PlaceForMeasures",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Academys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    AcademyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequisitesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Academys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Academys_Requisites_RequisitesId",
                        column: x => x.RequisitesId,
                        principalTable: "Requisites",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChatMessages",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskChatId = table.Column<int>(type: "int", nullable: true),
                    EventChatId = table.Column<int>(type: "int", nullable: true),
                    UserChatId = table.Column<int>(type: "int", nullable: true),
                    MeasureChatId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatMessages_UserChats_UserChatId",
                        column: x => x.UserChatId,
                        principalTable: "UserChats",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClientHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsAgreement = table.Column<bool>(type: "bit", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientStatusId = table.Column<int>(type: "int", nullable: true),
                    MeasurePowerBiId = table.Column<int>(type: "int", nullable: true),
                    PassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_ClientStatuses_ClientStatusId",
                        column: x => x.ClientStatusId,
                        principalTable: "ClientStatuses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    DateStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EducationFormId = table.Column<int>(type: "int", nullable: true),
                    AcademyId = table.Column<int>(type: "int", nullable: true),
                    SeasonOfBeginningId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_Academys_AcademyId",
                        column: x => x.AcademyId,
                        principalTable: "Academys",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contracts_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contracts_EducationForms_EducationFormId",
                        column: x => x.EducationFormId,
                        principalTable: "EducationForms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contracts_SeasonOfBeginning_SeasonOfBeginningId",
                        column: x => x.SeasonOfBeginningId,
                        principalTable: "SeasonOfBeginning",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MyStatPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MyStatLogin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login365 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonDocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfIssuePassport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDicount = table.Column<bool>(type: "bit", nullable: false),
                    DiscountDescription = table.Column<string>(name: "Discount_Description", type: "nvarchar(max)", nullable: false),
                    DiscountSum = table.Column<double>(type: "float", nullable: true),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Dashboards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dashboards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsImportant = table.Column<bool>(type: "bit", nullable: false),
                    Begin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskChatId = table.Column<int>(type: "int", nullable: true),
                    ClientHistoryId = table.Column<int>(type: "int", nullable: true),
                    DashBoardId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_ClientHistory_ClientHistoryId",
                        column: x => x.ClientHistoryId,
                        principalTable: "ClientHistory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tasks_Dashboards_DashBoardId",
                        column: x => x.DashBoardId,
                        principalTable: "Dashboards",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TaskChats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskId = table.Column<int>(type: "int", nullable: true),
                    TaskChatName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskChats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskChats_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TasksClients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskId = table.Column<int>(type: "int", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasksClients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TasksClients_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TasksClients_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UnderTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnderTaskName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnderTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnderTasks_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Begin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventChatId = table.Column<int>(type: "int", nullable: true),
                    ClientHistoryId = table.Column<int>(type: "int", nullable: true),
                    DashBoardId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_ClientHistory_ClientHistoryId",
                        column: x => x.ClientHistoryId,
                        principalTable: "ClientHistory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Events_Dashboards_DashBoardId",
                        column: x => x.DashBoardId,
                        principalTable: "Dashboards",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EventsChat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: true),
                    EventChatName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsChat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventsChat_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EventsClients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsClients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventsClients_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EventsClients_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EventsUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventsUsers_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MeasureChats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeasureId = table.Column<int>(type: "int", nullable: true),
                    MeasureChatName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasureChats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRoleId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelegramJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskChatId = table.Column<int>(type: "int", nullable: true),
                    LastTimeSignIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfPassportIssue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventChatId = table.Column<int>(type: "int", nullable: true),
                    MeasureChatId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskId = table.Column<int>(type: "int", nullable: true),
                    UnderTaskId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    WatchingPersonName = table.Column<string>(name: "WatchingPerson_Name", type: "nvarchar(max)", nullable: true),
                    WatchingPersonTaskId = table.Column<int>(name: "WatchingPerson_TaskId", type: "int", nullable: true),
                    WatchingPersonUnderTaskId = table.Column<int>(name: "WatchingPerson_UnderTaskId", type: "int", nullable: true),
                    WatchingPersonUserId = table.Column<int>(name: "WatchingPerson_UserId", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_EventsChat_EventChatId",
                        column: x => x.EventChatId,
                        principalTable: "EventsChat",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_MeasureChats_MeasureChatId",
                        column: x => x.MeasureChatId,
                        principalTable: "MeasureChats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_TaskChats_TaskChatId",
                        column: x => x.TaskChatId,
                        principalTable: "TaskChats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Tasks_WatchingPerson_TaskId",
                        column: x => x.WatchingPersonTaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_UnderTasks_UnderTaskId",
                        column: x => x.UnderTaskId,
                        principalTable: "UnderTasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_UnderTasks_WatchingPerson_UnderTaskId",
                        column: x => x.WatchingPersonUnderTaskId,
                        principalTable: "UnderTasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_UserRoles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Users_WatchingPerson_UserId",
                        column: x => x.WatchingPersonUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Measures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeasureName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Begin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    FreePlaces = table.Column<int>(type: "int", nullable: false),
                    MeasureChatId = table.Column<int>(type: "int", nullable: true),
                    PlaceForMeasureId = table.Column<int>(type: "int", nullable: true),
                    MeasurePowerBiId = table.Column<int>(type: "int", nullable: true),
                    ClientHistoryId = table.Column<int>(type: "int", nullable: true),
                    DashBoardId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Measures_ClientHistory_ClientHistoryId",
                        column: x => x.ClientHistoryId,
                        principalTable: "ClientHistory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Measures_Dashboards_DashBoardId",
                        column: x => x.DashBoardId,
                        principalTable: "Dashboards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Measures_PlaceForMeasures_PlaceForMeasureId",
                        column: x => x.PlaceForMeasureId,
                        principalTable: "PlaceForMeasures",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Measures_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TaskResponsiblePersons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    TaskId = table.Column<int>(type: "int", nullable: true),
                    UnderTaskId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskResponsiblePersons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskResponsiblePersons_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TaskResponsiblePersons_UnderTasks_UnderTaskId",
                        column: x => x.UnderTaskId,
                        principalTable: "UnderTasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TaskResponsiblePersons_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TasksUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasksUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TasksUsers_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TasksUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TasksWatchingPersons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    TaskId = table.Column<int>(type: "int", nullable: true),
                    UnderTaskId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasksWatchingPersons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TasksWatchingPersons_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TasksWatchingPersons_UnderTasks_UnderTaskId",
                        column: x => x.UnderTaskId,
                        principalTable: "UnderTasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TasksWatchingPersons_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserChatUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserChatId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserChatUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserChatUsers_UserChats_UserChatId",
                        column: x => x.UserChatId,
                        principalTable: "UserChats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserChatUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MeasurePowerBis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeasureId = table.Column<int>(type: "int", nullable: true),
                    ContractsCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurePowerBis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeasurePowerBis_Measures_MeasureId",
                        column: x => x.MeasureId,
                        principalTable: "Measures",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MeasuresClients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeasureId = table.Column<int>(type: "int", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasuresClients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeasuresClients_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MeasuresClients_Measures_MeasureId",
                        column: x => x.MeasureId,
                        principalTable: "Measures",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MeasuresPhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeasureId = table.Column<int>(type: "int", nullable: true),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasuresPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeasuresPhotos_Measures_MeasureId",
                        column: x => x.MeasureId,
                        principalTable: "Measures",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MeasuresVideos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeasureId = table.Column<int>(type: "int", nullable: true),
                    VideoPath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasuresVideos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeasuresVideos_Measures_MeasureId",
                        column: x => x.MeasureId,
                        principalTable: "Measures",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserAcceptStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    IsAccept = table.Column<bool>(type: "bit", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: true),
                    MeasureId = table.Column<int>(type: "int", nullable: true),
                    TaskId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAcceptStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAcceptStatuses_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAcceptStatuses_Measures_MeasureId",
                        column: x => x.MeasureId,
                        principalTable: "Measures",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAcceptStatuses_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAcceptStatuses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MeasuresUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeasureId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    UserMeasureAcceptStatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasuresUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeasuresUsers_Measures_MeasureId",
                        column: x => x.MeasureId,
                        principalTable: "Measures",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MeasuresUsers_UserAcceptStatuses_UserMeasureAcceptStatusId",
                        column: x => x.UserMeasureAcceptStatusId,
                        principalTable: "UserAcceptStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MeasuresUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Academys_RequisitesId",
                table: "Academys",
                column: "RequisitesId");

            migrationBuilder.CreateIndex(
                name: "IX_Academys_UserId",
                table: "Academys",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_EventChatId",
                table: "ChatMessages",
                column: "EventChatId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_MeasureChatId",
                table: "ChatMessages",
                column: "MeasureChatId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_TaskChatId",
                table: "ChatMessages",
                column: "TaskChatId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_UserChatId",
                table: "ChatMessages",
                column: "UserChatId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientHistory_ClientId",
                table: "ClientHistory",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientStatusId",
                table: "Clients",
                column: "ClientStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_MeasurePowerBiId",
                table: "Clients",
                column: "MeasurePowerBiId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_AcademyId",
                table: "Contracts",
                column: "AcademyId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ClientId",
                table: "Contracts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_EducationFormId",
                table: "Contracts",
                column: "EducationFormId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_SeasonOfBeginningId",
                table: "Contracts",
                column: "SeasonOfBeginningId");

            migrationBuilder.CreateIndex(
                name: "IX_Dashboards_UserId",
                table: "Dashboards",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ClientHistoryId",
                table: "Events",
                column: "ClientHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_DashBoardId",
                table: "Events",
                column: "DashBoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_UserId",
                table: "Events",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EventsChat_EventId",
                table: "EventsChat",
                column: "EventId",
                unique: true,
                filter: "[EventId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EventsClients_ClientId",
                table: "EventsClients",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_EventsClients_EventId",
                table: "EventsClients",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventsUsers_EventId",
                table: "EventsUsers",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventsUsers_UserId",
                table: "EventsUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasureChats_MeasureId",
                table: "MeasureChats",
                column: "MeasureId",
                unique: true,
                filter: "[MeasureId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurePowerBis_MeasureId",
                table: "MeasurePowerBis",
                column: "MeasureId",
                unique: true,
                filter: "[MeasureId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Measures_ClientHistoryId",
                table: "Measures",
                column: "ClientHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Measures_DashBoardId",
                table: "Measures",
                column: "DashBoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Measures_PlaceForMeasureId",
                table: "Measures",
                column: "PlaceForMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_Measures_UserId",
                table: "Measures",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasuresBusyTable_PlaceForMeasureId",
                table: "MeasuresBusyTable",
                column: "PlaceForMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasuresClients_ClientId",
                table: "MeasuresClients",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasuresClients_MeasureId",
                table: "MeasuresClients",
                column: "MeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasuresPhotos_MeasureId",
                table: "MeasuresPhotos",
                column: "MeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasuresUsers_MeasureId",
                table: "MeasuresUsers",
                column: "MeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasuresUsers_UserId",
                table: "MeasuresUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasuresUsers_UserMeasureAcceptStatusId",
                table: "MeasuresUsers",
                column: "UserMeasureAcceptStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasuresVideos_MeasureId",
                table: "MeasuresVideos",
                column: "MeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ContractId",
                table: "Students",
                column: "ContractId",
                unique: true,
                filter: "[ContractId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TaskChats_TaskId",
                table: "TaskChats",
                column: "TaskId",
                unique: true,
                filter: "[TaskId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TaskResponsiblePersons_TaskId",
                table: "TaskResponsiblePersons",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskResponsiblePersons_UnderTaskId",
                table: "TaskResponsiblePersons",
                column: "UnderTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskResponsiblePersons_UserId",
                table: "TaskResponsiblePersons",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ClientHistoryId",
                table: "Tasks",
                column: "ClientHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_DashBoardId",
                table: "Tasks",
                column: "DashBoardId");

            migrationBuilder.CreateIndex(
                name: "IX_TasksClients_ClientId",
                table: "TasksClients",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_TasksClients_TaskId",
                table: "TasksClients",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TasksUsers_TaskId",
                table: "TasksUsers",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TasksUsers_UserId",
                table: "TasksUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TasksWatchingPersons_TaskId",
                table: "TasksWatchingPersons",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TasksWatchingPersons_UnderTaskId",
                table: "TasksWatchingPersons",
                column: "UnderTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TasksWatchingPersons_UserId",
                table: "TasksWatchingPersons",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UnderTasks_TaskId",
                table: "UnderTasks",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAcceptStatuses_EventId",
                table: "UserAcceptStatuses",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAcceptStatuses_MeasureId",
                table: "UserAcceptStatuses",
                column: "MeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAcceptStatuses_TaskId",
                table: "UserAcceptStatuses",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAcceptStatuses_UserId",
                table: "UserAcceptStatuses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserChatUsers_UserChatId",
                table: "UserChatUsers",
                column: "UserChatId");

            migrationBuilder.CreateIndex(
                name: "IX_UserChatUsers_UserId",
                table: "UserChatUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_EventChatId",
                table: "Users",
                column: "EventChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_MeasureChatId",
                table: "Users",
                column: "MeasureChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TaskChatId",
                table: "Users",
                column: "TaskChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TaskId",
                table: "Users",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UnderTaskId",
                table: "Users",
                column: "UnderTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserId",
                table: "Users",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRoleId",
                table: "Users",
                column: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_WatchingPerson_TaskId",
                table: "Users",
                column: "WatchingPerson_TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_WatchingPerson_UnderTaskId",
                table: "Users",
                column: "WatchingPerson_UnderTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_WatchingPerson_UserId",
                table: "Users",
                column: "WatchingPerson_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Academys_Users_UserId",
                table: "Academys",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_EventsChat_EventChatId",
                table: "ChatMessages",
                column: "EventChatId",
                principalTable: "EventsChat",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_MeasureChats_MeasureChatId",
                table: "ChatMessages",
                column: "MeasureChatId",
                principalTable: "MeasureChats",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_TaskChats_TaskChatId",
                table: "ChatMessages",
                column: "TaskChatId",
                principalTable: "TaskChats",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientHistory_Clients_ClientId",
                table: "ClientHistory",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_MeasurePowerBis_MeasurePowerBiId",
                table: "Clients",
                column: "MeasurePowerBiId",
                principalTable: "MeasurePowerBis",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dashboards_Users_UserId",
                table: "Dashboards",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Users_UserId",
                table: "Events",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventsUsers_Users_UserId",
                table: "EventsUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MeasureChats_Measures_MeasureId",
                table: "MeasureChats",
                column: "MeasureId",
                principalTable: "Measures",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dashboards_Users_UserId",
                table: "Dashboards");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Users_UserId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Measures_Users_UserId",
                table: "Measures");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientHistory_Clients_ClientId",
                table: "ClientHistory");

            migrationBuilder.DropTable(
                name: "ChatMessages");

            migrationBuilder.DropTable(
                name: "EventsClients");

            migrationBuilder.DropTable(
                name: "EventsUsers");

            migrationBuilder.DropTable(
                name: "MeasuresBusyTable");

            migrationBuilder.DropTable(
                name: "MeasuresClients");

            migrationBuilder.DropTable(
                name: "MeasuresPhotos");

            migrationBuilder.DropTable(
                name: "MeasuresUsers");

            migrationBuilder.DropTable(
                name: "MeasuresVideos");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "TaskResponsiblePersons");

            migrationBuilder.DropTable(
                name: "TasksClients");

            migrationBuilder.DropTable(
                name: "TasksUsers");

            migrationBuilder.DropTable(
                name: "TasksWatchingPersons");

            migrationBuilder.DropTable(
                name: "UserChatUsers");

            migrationBuilder.DropTable(
                name: "UserAcceptStatuses");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "UserChats");

            migrationBuilder.DropTable(
                name: "Academys");

            migrationBuilder.DropTable(
                name: "EducationForms");

            migrationBuilder.DropTable(
                name: "SeasonOfBeginning");

            migrationBuilder.DropTable(
                name: "Requisites");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "EventsChat");

            migrationBuilder.DropTable(
                name: "MeasureChats");

            migrationBuilder.DropTable(
                name: "TaskChats");

            migrationBuilder.DropTable(
                name: "UnderTasks");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "ClientStatuses");

            migrationBuilder.DropTable(
                name: "MeasurePowerBis");

            migrationBuilder.DropTable(
                name: "Measures");

            migrationBuilder.DropTable(
                name: "ClientHistory");

            migrationBuilder.DropTable(
                name: "Dashboards");

            migrationBuilder.DropTable(
                name: "PlaceForMeasures");
        }
    }
}
