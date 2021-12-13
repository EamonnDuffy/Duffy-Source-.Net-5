using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace Duffy.Pages.V1
{
    public class LinkModel : PageModel
    {
        // Nested Classes.
        public class LinkInfo
        {
            public string Reference { get; set; }
            public string Name { get; set; }
            public string Uri { get; set; }
            public bool HttpsAvailable { get; set; }
            public bool ShowAlways { get; set; }
        };

        // MetaClass Attributes.
        public static LinkInfo[] _linkInfoList =
        {
            new LinkInfo
            {
                Reference = "R1000",
                Name = "Dublin City University (DCU, née NIHE)",
                Uri = "//www.Dcu.ie/",
                HttpsAvailable = true,
                ShowAlways = true
            },
            new LinkInfo
            {
                Reference = "R1001",
                Name = "Duffy Web Site",
                Uri = "//www.Duffy.global/",
                HttpsAvailable = true,
                ShowAlways = true
            },
            new LinkInfo
            {
                Reference = "R1002",
                Name = "Éamonn Anthony Duffy Web Site",
                Uri = "//www.Duffy.global/Éamonn Anthony Duffy/",
                HttpsAvailable = true,
                ShowAlways = false
            },
            new LinkInfo
            {
                Reference = "R2000",
                Name = "EVE",
                Uri = "//www.Eve.ie/",
                HttpsAvailable = true,
                ShowAlways = true
            },
            new LinkInfo
            {
                Reference = "R2001",
                Name = "GHIS",
                Uri = "//www.Ghis.eu/",
                HttpsAvailable = true,
                ShowAlways = true
            },
            new LinkInfo
            {
                Reference = "R2002",
                Name = "GHIS Student Portfolio",
                Uri = "//Web.Ghis.eu/Portfolio_EAD.html",
                HttpsAvailable = true,
                ShowAlways = true
            },
            new LinkInfo
            {
                Reference = "R2003",
                Name = "GHIS Web Design",
                Uri = "//Web.Ghis.eu/Index.html",
                HttpsAvailable = true,
                ShowAlways = true
            },
            new LinkInfo
            {
                Reference = "R3000",
                Name = "Medelec",
                // Previously:
                //  //www.CareFusion.com/
                Uri = "//www.Natus.com/",
                HttpsAvailable = false,
                ShowAlways = true
            },
            new LinkInfo
            {
                Reference = "R3001",
                Name = "Sony Broadcast & Professional",
                // Previously:
                //  //www.Sony.co.uk/Biz
                Uri = "//www.Sony.co.uk/Pro",
                HttpsAvailable = true,
                ShowAlways = true
            },
            new LinkInfo
            {
                Reference = "R3002",
                Name = "Kismet Studios",
                Uri = "//www.Eadent.com/",
                HttpsAvailable = true,
                ShowAlways = true
            },
            new LinkInfo
            {
                Reference = "R3003",
                Name = "GoldPlay UK",
                Uri = "//www.Eadent.com/",
                HttpsAvailable = true,
                ShowAlways = true
            },
            new LinkInfo
            {
                Reference = "R3004",
                Name = "MuseGaming",
                Uri = "//www.Eadent.com/",
                HttpsAvailable = true,
                ShowAlways = true
            },
            new LinkInfo
            {
                Reference = "R3005",
                Name = "Eadent",
                Uri = "//www.Eadent.com/",
                HttpsAvailable = true,
                ShowAlways = true
            },
            new LinkInfo
            {
                Reference = "R3006",
                Name = "MMI Research",
                Uri = "//www.Cobham.com/",
                HttpsAvailable = true,
                ShowAlways = true
            },
            new LinkInfo
            {
                Reference = "R3007",
                Name = "Axxia",
                //  6-Jun-2010: Redirects to: http://www.lexisnexis.org.uk/practiceandproductivitymanagement/
                // 16-Nov-2016: Redirects to: http://www.lexisnexis-es.co.uk/
                Uri = "//www.Axxia.com/",
                HttpsAvailable = false,
                ShowAlways = true
            },
            new LinkInfo
            {
                Reference = "R3008",
                Name = "CheckFree",
                //  6-Jun-2010: Redirects to: http://www.checkfree.fiserv.com/index.html
                // 16-Nov-2016: Redirects to: https://www.fiserv.com/index.aspx
                //  3-Sep-2018: www.CheckFree.com no longer appears to redirect.
                Uri = "//www.fiserv.com/",
                HttpsAvailable = true,
                ShowAlways = true
            },
            new LinkInfo
            {
                Reference = "R3009",
                Name = "Payzone",
                Uri = "//www.Payzone.ie/",
                HttpsAvailable = true,
                ShowAlways = true
            },
            new LinkInfo
            {
                Reference = "R4000",
                Name = "Rapture Web Site",
                Uri = "//www.Rapture.global/",
                HttpsAvailable = true,
                ShowAlways = true
            },
            new LinkInfo
            {
                Reference = "R4001",
                Name = "Rapture Therapy Web Site",
                Uri = "//Therapy.Rapture.global/",
                HttpsAvailable = true,
                ShowAlways = true
            },
        };

        // Model Properties.
        public LinkInfo[] LinkInfoList { get; set; }

        public bool ShowAll { get; set; }

        public IActionResult OnGet(string reference, string show = null)
        {
            IActionResult actionResult = null;
            
            if (reference != null)
            {
                reference = reference.ToUpper();

                foreach (var linkInfo in _linkInfoList)
                {
                    if (linkInfo.Reference == reference)
                    {
                        if (linkInfo.HttpsAvailable)
                            actionResult = Redirect("https:" + linkInfo.Uri);
                        else
                            actionResult = Redirect("http:" + linkInfo.Uri);

                        break;
                    }
                }
            }

            if (string.Equals(show, "All", StringComparison.OrdinalIgnoreCase))
                ShowAll = true;

            if (actionResult == null)
            {
                LinkInfoList = _linkInfoList;

                actionResult = Page();
            }

            return actionResult;
        }
    }
}
