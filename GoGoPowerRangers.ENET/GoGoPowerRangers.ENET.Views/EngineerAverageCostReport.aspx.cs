using GoGoPowerRangers.ENET.Data.ENETTableAdapters;
using GoGoPowerRangers.ENET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoGoPowerRangers.ENET.Views
{
    public partial class EngineerAverageCostReport : System.Web.UI.Page
    {
        private Accountant _user;
        private InterventionTableAdapter interventionTable = new InterventionTableAdapter();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                _user = (Accountant)Session["currentUser"];
                if (_user == null)
                    Response.Redirect("LoginPage.aspx");
            }
            catch
            {
                Response.Redirect("LoginPage.aspx");
            }
            

            var dbInterventions = interventionTable.GetInterventions();
            List<Intervention> interventions = new List<Intervention>();
            foreach (var dbInt in dbInterventions)
            {
                var intervention = _user.ConvertDbInterventionToIntervention(dbInt);
                interventions.Add(intervention);
            }
            var query = from Intervention in interventions
                        where
                          Intervention.Status == Status.Complete
                        group new { Intervention.Requester, Intervention } by new
                        {
                            Intervention.Requester.LastName,
                            Intervention.Requester.FirstName,
                        } into g
                        select new
                        {
                            AverageCosts = (decimal?)g.Average(p => p.Intervention.MaterialCost),
                            AverageHours = (decimal?)g.Average(p => p.Intervention.ManHours),
                            g.Key.LastName,
                            g.Key.FirstName,
                            Expr1 = (int?)g.Sum(p => p.Intervention.Id)

                        };

            var dataSource = query;
            EngineerAverageCostGrid.DataSource = dataSource;
            if (dataSource.Count() != 0 && EngineerAverageCostGrid.DataSource != null)
            {
                EngineerAverageCostGrid.DataBind();
                EngineerAverageCostGrid.UseAccessibleHeader = true;
                EngineerAverageCostGrid.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
                EngineerAverageCostGrid.DataBind();
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Accountant.aspx");
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session["currentUser"] = null;
            Response.Redirect("LoginPage.aspx", true);
        }
    }
}