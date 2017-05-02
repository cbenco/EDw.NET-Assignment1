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
    public partial class DistrictCostReport : System.Web.UI.Page
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
                        group new { Intervention.Requester.District, Intervention } by new
                        {
                            Intervention.Requester.District.Name
                        } into g
                        select new
                        {
                            TotalHours = (decimal?)g.Sum(p => p.Intervention.ManHours),
                            TotalCost = (decimal?)g.Sum(p => p.Intervention.MaterialCost),
                            DistrictName = g.Key.Name
                        };

            var dataSource = query;
            DistrictCostGrid.DataSource = dataSource;
            if (dataSource.Count() != 0 && DistrictCostGrid.DataSource != null)
            {
                DistrictCostGrid.DataBind();
                DistrictCostGrid.UseAccessibleHeader = true;
                DistrictCostGrid.HeaderRow.TableSection = TableRowSection.TableHeader;
                labelGrandTotalHours.Text = "Grand Total Hours: " + dataSource.Sum(c => c.TotalHours);
                labelGrandTotalCost.Text = "Grand Total Cost: $" + dataSource.Sum(c => c.TotalCost);
            }
            else
                DistrictCostGrid.DataBind();

            
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