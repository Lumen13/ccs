using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCS.Infr.Migrations
{
    /// <inheritdoc />
    public partial class OhlcvTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ohlcv_entities");

            migrationBuilder.CreateTable(
                name: "ohlcv_12h",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    open = table.Column<double>(type: "double precision", nullable: false),
                    close = table.Column<double>(type: "double precision", nullable: false),
                    high = table.Column<double>(type: "double precision", nullable: false),
                    low = table.Column<double>(type: "double precision", nullable: false),
                    volume = table.Column<double>(type: "double precision", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ohlcv_12h", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ohlcv_15m",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    open = table.Column<double>(type: "double precision", nullable: false),
                    close = table.Column<double>(type: "double precision", nullable: false),
                    high = table.Column<double>(type: "double precision", nullable: false),
                    low = table.Column<double>(type: "double precision", nullable: false),
                    volume = table.Column<double>(type: "double precision", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ohlcv_15m", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ohlcv_1d",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    open = table.Column<double>(type: "double precision", nullable: false),
                    close = table.Column<double>(type: "double precision", nullable: false),
                    high = table.Column<double>(type: "double precision", nullable: false),
                    low = table.Column<double>(type: "double precision", nullable: false),
                    volume = table.Column<double>(type: "double precision", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ohlcv_1d", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ohlcv_1h",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    open = table.Column<double>(type: "double precision", nullable: false),
                    close = table.Column<double>(type: "double precision", nullable: false),
                    high = table.Column<double>(type: "double precision", nullable: false),
                    low = table.Column<double>(type: "double precision", nullable: false),
                    volume = table.Column<double>(type: "double precision", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ohlcv_1h", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ohlcv_1m",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    open = table.Column<double>(type: "double precision", nullable: false),
                    close = table.Column<double>(type: "double precision", nullable: false),
                    high = table.Column<double>(type: "double precision", nullable: false),
                    low = table.Column<double>(type: "double precision", nullable: false),
                    volume = table.Column<double>(type: "double precision", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ohlcv_1m", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ohlcv_2h",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    open = table.Column<double>(type: "double precision", nullable: false),
                    close = table.Column<double>(type: "double precision", nullable: false),
                    high = table.Column<double>(type: "double precision", nullable: false),
                    low = table.Column<double>(type: "double precision", nullable: false),
                    volume = table.Column<double>(type: "double precision", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ohlcv_2h", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ohlcv_30m",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    open = table.Column<double>(type: "double precision", nullable: false),
                    close = table.Column<double>(type: "double precision", nullable: false),
                    high = table.Column<double>(type: "double precision", nullable: false),
                    low = table.Column<double>(type: "double precision", nullable: false),
                    volume = table.Column<double>(type: "double precision", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ohlcv_30m", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ohlcv_3m",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    open = table.Column<double>(type: "double precision", nullable: false),
                    close = table.Column<double>(type: "double precision", nullable: false),
                    high = table.Column<double>(type: "double precision", nullable: false),
                    low = table.Column<double>(type: "double precision", nullable: false),
                    volume = table.Column<double>(type: "double precision", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ohlcv_3m", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ohlcv_4h",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    open = table.Column<double>(type: "double precision", nullable: false),
                    close = table.Column<double>(type: "double precision", nullable: false),
                    high = table.Column<double>(type: "double precision", nullable: false),
                    low = table.Column<double>(type: "double precision", nullable: false),
                    volume = table.Column<double>(type: "double precision", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ohlcv_4h", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ohlcv_5m",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    open = table.Column<double>(type: "double precision", nullable: false),
                    close = table.Column<double>(type: "double precision", nullable: false),
                    high = table.Column<double>(type: "double precision", nullable: false),
                    low = table.Column<double>(type: "double precision", nullable: false),
                    volume = table.Column<double>(type: "double precision", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ohlcv_5m", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ohlcv_6h",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    open = table.Column<double>(type: "double precision", nullable: false),
                    close = table.Column<double>(type: "double precision", nullable: false),
                    high = table.Column<double>(type: "double precision", nullable: false),
                    low = table.Column<double>(type: "double precision", nullable: false),
                    volume = table.Column<double>(type: "double precision", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ohlcv_6h", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_ohlcv_12h_timestamp",
                table: "ohlcv_12h",
                column: "timestamp");

            migrationBuilder.CreateIndex(
                name: "ix_ohlcv_15m_timestamp",
                table: "ohlcv_15m",
                column: "timestamp");

            migrationBuilder.CreateIndex(
                name: "ix_ohlcv_1d_timestamp",
                table: "ohlcv_1d",
                column: "timestamp");

            migrationBuilder.CreateIndex(
                name: "ix_ohlcv_1h_timestamp",
                table: "ohlcv_1h",
                column: "timestamp");

            migrationBuilder.CreateIndex(
                name: "ix_ohlcv_1m_timestamp",
                table: "ohlcv_1m",
                column: "timestamp");

            migrationBuilder.CreateIndex(
                name: "ix_ohlcv_2h_timestamp",
                table: "ohlcv_2h",
                column: "timestamp");

            migrationBuilder.CreateIndex(
                name: "ix_ohlcv_30m_timestamp",
                table: "ohlcv_30m",
                column: "timestamp");

            migrationBuilder.CreateIndex(
                name: "ix_ohlcv_3m_timestamp",
                table: "ohlcv_3m",
                column: "timestamp");

            migrationBuilder.CreateIndex(
                name: "ix_ohlcv_4h_timestamp",
                table: "ohlcv_4h",
                column: "timestamp");

            migrationBuilder.CreateIndex(
                name: "ix_ohlcv_5m_timestamp",
                table: "ohlcv_5m",
                column: "timestamp");

            migrationBuilder.CreateIndex(
                name: "ix_ohlcv_6h_timestamp",
                table: "ohlcv_6h",
                column: "timestamp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ohlcv_12h");

            migrationBuilder.DropTable(
                name: "ohlcv_15m");

            migrationBuilder.DropTable(
                name: "ohlcv_1d");

            migrationBuilder.DropTable(
                name: "ohlcv_1h");

            migrationBuilder.DropTable(
                name: "ohlcv_1m");

            migrationBuilder.DropTable(
                name: "ohlcv_2h");

            migrationBuilder.DropTable(
                name: "ohlcv_30m");

            migrationBuilder.DropTable(
                name: "ohlcv_3m");

            migrationBuilder.DropTable(
                name: "ohlcv_4h");

            migrationBuilder.DropTable(
                name: "ohlcv_5m");

            migrationBuilder.DropTable(
                name: "ohlcv_6h");

            migrationBuilder.CreateTable(
                name: "ohlcv_entities",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    close = table.Column<double>(type: "double precision", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    high = table.Column<double>(type: "double precision", nullable: false),
                    low = table.Column<double>(type: "double precision", nullable: false),
                    open = table.Column<double>(type: "double precision", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    volume = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ohlcv_entities", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_ohlcv_timestamp",
                table: "ohlcv_entities",
                column: "timestamp");
        }
    }
}
