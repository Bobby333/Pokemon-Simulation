using Microsoft.EntityFrameworkCore.Migrations;

namespace PokemonSimulation.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abilitys",
                columns: table => new
                {
                    Id_Ability = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ability_Name = table.Column<string>(nullable: true),
                    Ability_Description = table.Column<string>(nullable: true),
                    Ability_Boost = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilitys", x => x.Id_Ability);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item_Name = table.Column<string>(nullable: true),
                    Item_Description = table.Column<string>(nullable: true),
                    Item_boost = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "Moves",
                columns: table => new
                {
                    MoveId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Move_Name = table.Column<string>(nullable: true),
                    Move_Description = table.Column<string>(nullable: true),
                    Move_Power = table.Column<int>(nullable: false),
                    Move_Type = table.Column<string>(nullable: true),
                    Move_Amount = table.Column<int>(nullable: false),
                    Accuracy = table.Column<int>(nullable: false),
                    Move_dType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moves", x => x.MoveId);
                });

            migrationBuilder.CreateTable(
                name: "Simulation",
                columns: table => new
                {
                    SimulationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Simulation", x => x.SimulationID);
                });

            migrationBuilder.CreateTable(
                name: "Pokedex",
                columns: table => new
                {
                    PokemonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pokemon_Name = table.Column<string>(nullable: true),
                    Type1 = table.Column<string>(nullable: true),
                    Type2 = table.Column<string>(nullable: true),
                    HP = table.Column<int>(nullable: false),
                    Attack = table.Column<int>(nullable: false),
                    Defense = table.Column<int>(nullable: false),
                    Special_Attack = table.Column<int>(nullable: false),
                    Special_Defense = table.Column<int>(nullable: false),
                    Speed = table.Column<int>(nullable: false),
                    Total = table.Column<int>(nullable: false),
                    SimulationsSimulationID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokedex", x => x.PokemonId);
                    table.ForeignKey(
                        name: "FK_Pokedex_Simulation_SimulationsSimulationID",
                        column: x => x.SimulationsSimulationID,
                        principalTable: "Simulation",
                        principalColumn: "SimulationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbilityAssignment",
                columns: table => new
                {
                    AssiggnedAbilityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AbilityID = table.Column<int>(nullable: false),
                    PokedexID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbilityAssignment", x => x.AssiggnedAbilityID);
                    table.ForeignKey(
                        name: "FK_AbilityAssignment_Abilitys_AbilityID",
                        column: x => x.AbilityID,
                        principalTable: "Abilitys",
                        principalColumn: "Id_Ability",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbilityAssignment_Pokedex_PokedexID",
                        column: x => x.PokedexID,
                        principalTable: "Pokedex",
                        principalColumn: "PokemonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoveAssignment",
                columns: table => new
                {
                    AssighnedID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MoveID = table.Column<int>(nullable: false),
                    PokedexID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoveAssignment", x => x.AssighnedID);
                    table.ForeignKey(
                        name: "FK_MoveAssignment_Moves_MoveID",
                        column: x => x.MoveID,
                        principalTable: "Moves",
                        principalColumn: "MoveId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoveAssignment_Pokedex_PokedexID",
                        column: x => x.PokedexID,
                        principalTable: "Pokedex",
                        principalColumn: "PokemonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbilityAssignment_AbilityID",
                table: "AbilityAssignment",
                column: "AbilityID");

            migrationBuilder.CreateIndex(
                name: "IX_AbilityAssignment_PokedexID",
                table: "AbilityAssignment",
                column: "PokedexID");

            migrationBuilder.CreateIndex(
                name: "IX_MoveAssignment_MoveID",
                table: "MoveAssignment",
                column: "MoveID");

            migrationBuilder.CreateIndex(
                name: "IX_MoveAssignment_PokedexID",
                table: "MoveAssignment",
                column: "PokedexID");

            migrationBuilder.CreateIndex(
                name: "IX_Pokedex_SimulationsSimulationID",
                table: "Pokedex",
                column: "SimulationsSimulationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbilityAssignment");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "MoveAssignment");

            migrationBuilder.DropTable(
                name: "Abilitys");

            migrationBuilder.DropTable(
                name: "Moves");

            migrationBuilder.DropTable(
                name: "Pokedex");

            migrationBuilder.DropTable(
                name: "Simulation");
        }
    }
}
