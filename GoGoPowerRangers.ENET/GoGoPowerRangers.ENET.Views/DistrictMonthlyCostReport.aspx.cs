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
    public partial class DistrictMonthlyCostReport : System.Web.UI.Page
    {
        private Accountant _user;
        private InterventionTableAdapter interventionTable = new InterventionTableAdapter();
        private DistrictTableAdapter districtTable = new DistrictTableAdapter();
        List<Intervention> _interventions = new List<Intervention>();
        List<District> _districts = new List<District>();
        private int _selectedId = 1;
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


            try
            {
                var dbDistricts = districtTable.GetDistricts();
                var dbInterventions = interventionTable.GetInterventions();

                foreach (var dbInt in dbInterventions)
                {
                    var intervention = _user.ConvertDbInterventionToIntervention(dbInt);
                    _interventions.Add(intervention);
                }

                foreach (var dbDist in dbDistricts)
                {
                    var district = _user.ConvertDbDistricttoDistrict(dbDist);
                    _districts.Add(district);
                }
            }
            catch
            {
                Response.Redirect("LoginPage.aspx");
            }



            if (!IsPostBack)
            {
                districtDropdown.DataSource = _districts;
                districtDropdown.DataTextField = "Name";
                districtDropdown.DataValueField = "Id";
                districtDropdown.DataBind();
                SetDataGrid();
            }
            
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

        protected void districts_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = districtDropdown.SelectedValue;
            int.TryParse(selected, out _selectedId);
            SetDataGrid();
        }

        protected void SetDataGrid()
        {
            

            var query = from Intervention in _interventions
                        where
                          Intervention.Requester.District.Id == _selectedId
                        group Intervention by new
                        {
                            Column1 = (string)Intervention.RequestDate.ToString("MMMM")
                        } into g
                        select new
                        {
                            TotalCost = (decimal?)g.Sum(p => p.MaterialCost),
                            TotalHours = (decimal?)g.Sum(p => p.ManHours),
                            InterventionMonth = g.Key.Column1
                        };


            var dataSource = query;
            DistrictMonthlyCostGrid.DataSource = dataSource;
            if (dataSource.Count() != 0 && DistrictMonthlyCostGrid.DataSource != null)
            {
                DistrictMonthlyCostGrid.DataBind();
                DistrictMonthlyCostGrid.UseAccessibleHeader = true;
                DistrictMonthlyCostGrid.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}