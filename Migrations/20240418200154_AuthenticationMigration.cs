using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bancodedados.Migrations
{
    /// <inheritdoc />
    public partial class AuthenticationMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auth",
                columns: table => new
                {
                    useremail = table.Column<string>(name: "user_email", type: "text", nullable: false),
                    password = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auth", x => x.useremail);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: true),
                    guidparent = table.Column<Guid>(name: "guid_parent", type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.guid);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_guid_parent",
                        column: x => x.guidparent,
                        principalTable: "Categories",
                        principalColumn: "guid");
                });

            migrationBuilder.CreateTable(
                name: "CollaborationPermissions",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollaborationPermissions", x => x.guid);
                });

            migrationBuilder.CreateTable(
                name: "UserPermissions",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermissions", x => x.guid);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    email = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    passhash = table.Column<int>(name: "pass_hash", type: "integer", nullable: false),
                    guidpermission = table.Column<Guid>(name: "guid_permission", type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.email);
                    table.ForeignKey(
                        name: "FK_Users_Auth_email",
                        column: x => x.email,
                        principalTable: "Auth",
                        principalColumn: "user_email",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_UserPermissions_guid_permission",
                        column: x => x.guidpermission,
                        principalTable: "UserPermissions",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: true),
                    subtitle = table.Column<string>(type: "text", nullable: true),
                    content = table.Column<string>(type: "text", nullable: true),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    approved = table.Column<bool>(type: "boolean", nullable: false),
                    useremail = table.Column<string>(name: "user_email", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.guid);
                    table.ForeignKey(
                        name: "FK_Posts_Users_user_email",
                        column: x => x.useremail,
                        principalTable: "Users",
                        principalColumn: "email");
                });

            migrationBuilder.CreateTable(
                name: "CategoryModelPostModel",
                columns: table => new
                {
                    Categoriesguid = table.Column<Guid>(type: "uuid", nullable: false),
                    Postsguid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryModelPostModel", x => new { x.Categoriesguid, x.Postsguid });
                    table.ForeignKey(
                        name: "FK_CategoryModelPostModel_Categories_Categoriesguid",
                        column: x => x.Categoriesguid,
                        principalTable: "Categories",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryModelPostModel_Posts_Postsguid",
                        column: x => x.Postsguid,
                        principalTable: "Posts",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Collaborations",
                columns: table => new
                {
                    useremail = table.Column<string>(name: "user_email", type: "text", nullable: false),
                    guidpost = table.Column<Guid>(name: "guid_post", type: "uuid", nullable: false),
                    guidCollaborationpermission = table.Column<Guid>(name: "guid_Collaboration_permission", type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaborations", x => new { x.useremail, x.guidpost });
                    table.ForeignKey(
                        name: "FK_Collaborations_CollaborationPermissions_guid_Collaboration_~",
                        column: x => x.guidCollaborationpermission,
                        principalTable: "CollaborationPermissions",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Collaborations_Posts_guid_post",
                        column: x => x.guidpost,
                        principalTable: "Posts",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Collaborations_Users_user_email",
                        column: x => x.useremail,
                        principalTable: "Users",
                        principalColumn: "email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uuid", nullable: false),
                    content = table.Column<string>(type: "text", nullable: true),
                    useremail = table.Column<string>(name: "user_email", type: "text", nullable: true),
                    guidpost = table.Column<Guid>(name: "guid_post", type: "uuid", nullable: false),
                    publishdate = table.Column<DateTime>(name: "publish_date", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.guid);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_guid_post",
                        column: x => x.guidpost,
                        principalTable: "Posts",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_user_email",
                        column: x => x.useremail,
                        principalTable: "Users",
                        principalColumn: "email");
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    useremail = table.Column<string>(name: "user_email", type: "text", nullable: false),
                    guidpost = table.Column<Guid>(name: "guid_post", type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => new { x.useremail, x.guidpost });
                    table.ForeignKey(
                        name: "FK_Likes_Posts_guid_post",
                        column: x => x.guidpost,
                        principalTable: "Posts",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_Users_user_email",
                        column: x => x.useremail,
                        principalTable: "Users",
                        principalColumn: "email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_guid_parent",
                table: "Categories",
                column: "guid_parent");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryModelPostModel_Postsguid",
                table: "CategoryModelPostModel",
                column: "Postsguid");

            migrationBuilder.CreateIndex(
                name: "IX_Collaborations_guid_Collaboration_permission",
                table: "Collaborations",
                column: "guid_Collaboration_permission");

            migrationBuilder.CreateIndex(
                name: "IX_Collaborations_guid_post",
                table: "Collaborations",
                column: "guid_post");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_guid_post",
                table: "Comments",
                column: "guid_post");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_user_email",
                table: "Comments",
                column: "user_email");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_guid_post",
                table: "Likes",
                column: "guid_post");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_user_email",
                table: "Posts",
                column: "user_email");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissions_name",
                table: "UserPermissions",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_guid_permission",
                table: "Users",
                column: "guid_permission");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryModelPostModel");

            migrationBuilder.DropTable(
                name: "Collaborations");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "CollaborationPermissions");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Auth");

            migrationBuilder.DropTable(
                name: "UserPermissions");
        }
    }
}
