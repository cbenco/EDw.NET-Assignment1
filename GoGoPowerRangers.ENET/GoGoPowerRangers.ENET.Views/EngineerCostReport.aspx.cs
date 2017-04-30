using GoGoPowerRangers.ENET.Data.ENETTableAdapters;
using GoGoPowerRangers.ENET.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoGoPowerRangers.ENET.Views
{
    public partial class EngineerCostReport : System.Web.UI.Page
    {
        private Accountant _user;
        private InterventionTableAdapter interventionTable = new InterventionTableAdapter();
        protected void Page_Load(object sender, EventArgs e)
        {
            _user = (Accountant)Session["currentUser"];
                      
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
                            TotalCost = (decimal?)g.Sum(p => p.Intervention.MaterialCost),
                            TotalHours = (decimal?)g.Sum(p => p.Intervention.ManHours),
                            g.Key.LastName,
                            g.Key.FirstName,
                            Expr1 = (int?)g.Sum(p => p.Intervention.Id)
                            
                        };
            EngineerCostGrid.DataSource = query;
            EngineerCostGrid.DataBind();
            EngineerCostGrid.UseAccessibleHeader = true;
            EngineerCostGrid.HeaderRow.TableSection = TableRowSection.TableHeader;
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