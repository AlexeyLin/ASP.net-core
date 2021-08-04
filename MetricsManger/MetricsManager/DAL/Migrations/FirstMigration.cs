using FluentMigrator;

namespace MetricsManager.DAL.Migrations
{
    [Migration(1)]
    public class FirstMigration : Migration
    {
        public override void Up()
        {
            Create.Table("cpumetrics")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("AgentId").AsInt32()
                .WithColumn("Value").AsInt32()
                .WithColumn("Time").AsInt64();
            Create.Table("dotnetmetrics")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("AgentId").AsInt32()
                .WithColumn("Value").AsInt32()
                .WithColumn("Time").AsInt64();
            Create.Table("hddmetrics")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("AgentId").AsInt32()
                .WithColumn("Value").AsInt32()
                .WithColumn("Time").AsInt64();
            Create.Table("networkmetrics")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("AgentId").AsInt32()
                .WithColumn("Value").AsInt32()
                .WithColumn("Time").AsInt64();
            Create.Table("rammetrics")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("AgentId").AsInt32()
                .WithColumn("Value").AsInt32()
                .WithColumn("Time").AsInt64();
            Create.Table("agents")
                .WithColumn("Id").AsInt64().PrimaryKey()
                .WithColumn("Address").AsString()
                .WithColumn("Status").AsString().WithDefaultValue("Enable");
            Create.ForeignKey("fk_cpumetrics_agentId")
                .FromTable("cpumetrics").ForeignColumn("AgentId")
                .ToTable("agents").PrimaryColumn("Id");
            Create.ForeignKey("fk_dotnetmetrics_agentId")
                .FromTable("dotnetmetrics").ForeignColumn("AgentId")
                .ToTable("agents").PrimaryColumn("Id");
            Create.ForeignKey("fk_hddmetrics_agentId")
                .FromTable("hddmetrics").ForeignColumn("AgentId")
                .ToTable("agents").PrimaryColumn("Id");
            Create.ForeignKey("fk_networkmetrics_agentId")
                .FromTable("networkmetrics").ForeignColumn("AgentId")
                .ToTable("agents").PrimaryColumn("Id");
            Create.ForeignKey("fk_rammetrics_agentId")
                .FromTable("rammetrics").ForeignColumn("AgentId")
                .ToTable("agents").PrimaryColumn("Id");
        }

        public override void Down()
        {
            Delete.Table("cpumetrics");
            Delete.Table("dotnetmetrics");
            Delete.Table("hddmetrics");
            Delete.Table("networkmetrics");
            Delete.Table("rammetrics");
            Delete.Table("agents");
        }
    }
}