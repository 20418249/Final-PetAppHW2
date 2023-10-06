using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PetAppHW2.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "campaigns",
                columns: table => new
                {
                    campaignId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    campaignAmmount = table.Column<double>(type: "float", nullable: false),
                    currentAmmount = table.Column<double>(type: "float", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_campaigns", x => x.campaignId);
                });

            migrationBuilder.CreateTable(
                name: "genders",
                columns: table => new
                {
                    genderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genders", x => x.genderId);
                });

            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    locationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locations", x => x.locationId);
                });

            migrationBuilder.CreateTable(
                name: "petBreeds",
                columns: table => new
                {
                    petBreedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_petBreeds", x => x.petBreedId);
                });

            migrationBuilder.CreateTable(
                name: "petTypes",
                columns: table => new
                {
                    petTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_petTypes", x => x.petTypeId);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "donations",
                columns: table => new
                {
                    donationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ammount = table.Column<double>(type: "float", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    campaignId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donations", x => x.donationId);
                    table.ForeignKey(
                        name: "FK_donations_campaigns_campaignId",
                        column: x => x.campaignId,
                        principalTable: "campaigns",
                        principalColumn: "campaignId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_donations_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    petId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    petTypeId = table.Column<int>(type: "int", nullable: false),
                    petBreedId = table.Column<int>(type: "int", nullable: false),
                    locationId = table.Column<int>(type: "int", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    weight = table.Column<double>(type: "float", nullable: false),
                    genderId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.petId);
                    table.ForeignKey(
                        name: "FK_Pets_genders_genderId",
                        column: x => x.genderId,
                        principalTable: "genders",
                        principalColumn: "genderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pets_locations_locationId",
                        column: x => x.locationId,
                        principalTable: "locations",
                        principalColumn: "locationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pets_petBreeds_petBreedId",
                        column: x => x.petBreedId,
                        principalTable: "petBreeds",
                        principalColumn: "petBreedId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pets_petTypes_petTypeId",
                        column: x => x.petTypeId,
                        principalTable: "petTypes",
                        principalColumn: "petTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pets_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "userId");
                });

            migrationBuilder.InsertData(
                table: "campaigns",
                columns: new[] { "campaignId", "campaignAmmount", "currentAmmount", "isActive", "name" },
                values: new object[,]
                {
                    { 1, 10000.0, 50.0, true, "Woof Food Drive" },
                    { 2, 12000.0, 3000.0, true, "Paws for a Cause" },
                    { 3, 8000.0, 1500.0, true, "Meow Mission: Helping Homeless Cats" },
                    { 4, 18000.0, 6000.0, true, "Bark Aid: Shelter Support for Dogs" }
                });

            migrationBuilder.InsertData(
                table: "genders",
                columns: new[] { "genderId", "description" },
                values: new object[,]
                {
                    { 1, "Male" },
                    { 2, "Female" }
                });

            migrationBuilder.InsertData(
                table: "locations",
                columns: new[] { "locationId", "name" },
                values: new object[,]
                {
                    { 1, "Gauteng" },
                    { 2, "North West" },
                    { 3, "Limpopo" },
                    { 4, "Western Cape" },
                    { 5, "Eastern Cape" },
                    { 6, "Northern Cape" },
                    { 7, "Freestate" },
                    { 8, "Kwazulu Natal" }
                });

            migrationBuilder.InsertData(
                table: "petBreeds",
                columns: new[] { "petBreedId", "description" },
                values: new object[,]
                {
                    { 1, "Labrador" },
                    { 2, "German Shepherd" },
                    { 3, "Persian" },
                    { 4, "Burmese" },
                    { 5, "Maine Coon" },
                    { 6, "Siamese" },
                    { 7, "Australian Shepherd" },
                    { 8, "Dalmatian" },
                    { 9, "Yorkshire Terrier" },
                    { 10, "Belgian Malanois" }
                });

            migrationBuilder.InsertData(
                table: "petTypes",
                columns: new[] { "petTypeId", "description" },
                values: new object[,]
                {
                    { 1, "Dog" },
                    { 2, "Cat" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "userId", "address", "email", "name", "phone", "surname" },
                values: new object[,]
                {
                    { 1, "1282 Boundary Ln, Hatfield, Pretoria", "christiaanholm20@gmail.com", "Christiaan", "081 481 0285", "Holm" },
                    { 2, "45 Acacia Street, Johannesburg, Gauteng", "sophia.vandermerwe@example.com", "Sophia", "082 555 9876", "van der Merwe" },
                    { 3, "22 Jacaranda Avenue, Durban, KwaZulu-Natal", "alex.smith@example.com", "Alex", "071 234 5678", "Smith" },
                    { 4, "78 Protea Road, Cape Town, Western Cape", "james.johnson@example.com", "James", "084 876 5432", "Johnson" },
                    { 5, "12 Marula Lane, Port Elizabeth, Eastern Cape", "emily.brown@example.com", "Emily", "083 765 4321", "Brown" },
                    { 6, "9 Baobab Street, Bloemfontein, Free State", "liam.khumalo@example.com", "Liam", "079 555 8888", "Khumalo" },
                    { 7, "33 Maroela Road, Polokwane, Limpopo", "noah.ndlovu@example.com", "Noah", "072 444 9999", "Ndlovu" },
                    { 8, "67 Eucalyptus Crescent, Nelspruit, Mpumalanga", "ava.williams@example.com", "Ava", "076 222 3333", "Williams" },
                    { 9, "5 Protea Avenue, Kimberley, Northern Cape", "william.molefe@example.com", "William", "073 111 2222", "Molefe" },
                    { 10, "18 Baobab Street, Rustenburg, North West", "olivia.clark@example.com", "Olivia", "081 333 4444", "Clark" }
                });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "petId", "age", "genderId", "image", "locationId", "name", "petBreedId", "petTypeId", "userId", "weight" },
                values: new object[,]
                {
                    { 1, 6, 1, "iamge placeholder", 2, "Benji", 2, 1, 1, 27.0 },
                    { 2, 4, 2, "", 5, "Buddy", 7, 2, 3, 15.5 },
                    { 3, 2, 1, "image placeholder", 4, "Luna", 3, 1, 8, 12.800000000000001 },
                    { 4, 7, 2, "", 7, "Milo", 9, 2, null, 19.300000000000001 },
                    { 5, 9, 1, "image placeholder", 1, "Max", 5, 1, 5, 21.0 },
                    { 6, 12, 2, "", 3, "Daisy", 8, 2, 7, 8.6999999999999993 }
                });

            migrationBuilder.InsertData(
                table: "donations",
                columns: new[] { "donationId", "ammount", "campaignId", "userId" },
                values: new object[] { 1, 50.0, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_donations_campaignId",
                table: "donations",
                column: "campaignId");

            migrationBuilder.CreateIndex(
                name: "IX_donations_userId",
                table: "donations",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_genderId",
                table: "Pets",
                column: "genderId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_locationId",
                table: "Pets",
                column: "locationId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_petBreedId",
                table: "Pets",
                column: "petBreedId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_petTypeId",
                table: "Pets",
                column: "petTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_userId",
                table: "Pets",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "donations");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "campaigns");

            migrationBuilder.DropTable(
                name: "genders");

            migrationBuilder.DropTable(
                name: "locations");

            migrationBuilder.DropTable(
                name: "petBreeds");

            migrationBuilder.DropTable(
                name: "petTypes");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
