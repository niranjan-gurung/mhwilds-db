using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mhwilds_api.Migrations
{
    /// <inheritdoc />
    public partial class ChangeResistancesToIntFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                ALTER TABLE ""Resistances"" 
                ALTER COLUMN ""Fire"" TYPE integer 
                USING CASE 
                    WHEN ""Fire"" IS NULL OR ""Fire"" = '' THEN 0
                    WHEN ""Fire"" ~ '^-?[0-9]+$' THEN ""Fire""::integer
                    ELSE 0
                END;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE ""Resistances"" 
                ALTER COLUMN ""Water"" TYPE integer 
                USING CASE 
                    WHEN ""Water"" IS NULL OR ""Water"" = '' THEN 0
                    WHEN ""Water"" ~ '^-?[0-9]+$' THEN ""Water""::integer
                    ELSE 0
                END;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE ""Resistances"" 
                ALTER COLUMN ""Ice"" TYPE integer 
                USING CASE 
                    WHEN ""Ice"" IS NULL OR ""Ice"" = '' THEN 0
                    WHEN ""Ice"" ~ '^-?[0-9]+$' THEN ""Ice""::integer
                    ELSE 0
                END;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE ""Resistances"" 
                ALTER COLUMN ""Thunder"" TYPE integer 
                USING CASE 
                    WHEN ""Thunder"" IS NULL OR ""Thunder"" = '' THEN 0
                    WHEN ""Thunder"" ~ '^-?[0-9]+$' THEN ""Thunder""::integer
                    ELSE 0
                END;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE ""Resistances"" 
                ALTER COLUMN ""Dragon"" TYPE integer 
                USING CASE 
                    WHEN ""Dragon"" IS NULL OR ""Dragon"" = '' THEN 0
                    WHEN ""Dragon"" ~ '^-?[0-9]+$' THEN ""Dragon""::integer
                    ELSE 0
                END;
            ");

            // Set NOT NULL constraints if needed
            migrationBuilder.Sql(@"
                ALTER TABLE ""Resistances"" 
                ALTER COLUMN ""Fire"" SET NOT NULL;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE ""Resistances"" 
                ALTER COLUMN ""Water"" SET NOT NULL;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE ""Resistances"" 
                ALTER COLUMN ""Ice"" SET NOT NULL;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE ""Resistances"" 
                ALTER COLUMN ""Thunder"" SET NOT NULL;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE ""Resistances"" 
                ALTER COLUMN ""Dragon"" SET NOT NULL;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                ALTER TABLE ""Resistances"" 
                ALTER COLUMN ""Fire"" TYPE text 
                USING ""Fire""::text;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE ""Resistances"" 
                ALTER COLUMN ""Water"" TYPE text 
                USING ""Water""::text;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE ""Resistances"" 
                ALTER COLUMN ""Ice"" TYPE text 
                USING ""Ice""::text;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE ""Resistances"" 
                ALTER COLUMN ""Thunder"" TYPE text 
                USING ""Thunder""::text;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE ""Resistances"" 
                ALTER COLUMN ""Dragon"" TYPE text 
                USING ""Dragon""::text;
            ");

            // Remove NOT NULL constraints
            migrationBuilder.Sql(@"
                ALTER TABLE ""Resistances"" 
                ALTER COLUMN ""Fire"" DROP NOT NULL;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE ""Resistances"" 
                ALTER COLUMN ""Water"" DROP NOT NULL;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE ""Resistances"" 
                ALTER COLUMN ""Ice"" DROP NOT NULL;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE ""Resistances"" 
                ALTER COLUMN ""Thunder"" DROP NOT NULL;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE ""Resistances"" 
                ALTER COLUMN ""Dragon"" DROP NOT NULL;
            ");
        }
    }
}
