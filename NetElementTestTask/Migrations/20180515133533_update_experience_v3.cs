using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NetElementTestTask.Migrations
{
    public partial class update_experience_v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_Departments_DepartmentId",
                table: "Experiences");

            migrationBuilder.DropIndex(
                name: "IX_Experiences_DepartmentId",
                table: "Experiences");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Experiences",
                newName: "CollaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_CollaboratorId",
                table: "Experiences",
                column: "CollaboratorId",
                unique: true,
                filter: "[CollaboratorId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_Collaborators_CollaboratorId",
                table: "Experiences",
                column: "CollaboratorId",
                principalTable: "Collaborators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_Collaborators_CollaboratorId",
                table: "Experiences");

            migrationBuilder.DropIndex(
                name: "IX_Experiences_CollaboratorId",
                table: "Experiences");

            migrationBuilder.RenameColumn(
                name: "CollaboratorId",
                table: "Experiences",
                newName: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_DepartmentId",
                table: "Experiences",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_Departments_DepartmentId",
                table: "Experiences",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
