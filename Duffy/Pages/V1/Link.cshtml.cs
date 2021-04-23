using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        };

        // MetaClass Attributes.
        public static LinkInfo[] _linkInfoList =
        {
            new LinkInfo
            {
                Reference = "R1000",
                Name = "Dublin City University (DCU, née NIHE)",
                Uri = "//www.Dcu.ie/",
                HttpsAvailable = true
            },
            new LinkInfo
            {
                Reference = "R1001",
                Name = "Duffy Web Site",
                Uri = "//www.Duffy.global/",
                HttpsAvailable = true
            },
            new LinkInfo
            {
                Reference = "R1002",
                Name = "Éamonn Anthony Duffy Web Site",
                Uri = "//www.Duffy.global/Éamonn Anthony Duffy/",
                HttpsAvailable = true
            },
            new LinkInfo
            {
                Reference = "R1003",
                Name = "Therapy Web Site",
                Uri = "//www.Duffy.global/Éamonn Anthony Duffy/Documentation/Therapy/",
                HttpsAvailable = true
            },
            new LinkInfo
            {
                Reference = "R2000",
                Name = "EVE",
                Uri = "//www.Eve.ie/",
                HttpsAvailable = true
            },
            new LinkInfo
            {
                Reference = "R2001",
                Name = "GHIS",
                Uri = "//www.Ghis.eu/",
                HttpsAvailable = true
            },
            new LinkInfo
            {
                Reference = "R2002",
                Name = "GHIS Student Portfolio",
                Uri = "//Web.Ghis.eu/Portfolio_EAD.html",
                HttpsAvailable = false
            },
            new LinkInfo
            {
                Reference = "R3000",
                Name = "Medelec",
                // Previously:
                //  //www.CareFusion.com/
                Uri = "//www.Natus.com/",
                HttpsAvailable = false
            },
            new LinkInfo
            {
                Reference = "R3001",
                Name = "Sony Broadcast & Professional",
                // Previously:
                //  //www.Sony.co.uk/Biz
                Uri = "//www.Sony.co.uk/Pro",
                HttpsAvailable = true
            },
            new LinkInfo
            {
                Reference = "R3002",
                Name = "Kismet Studios",
                Uri = "//www.Eadent.com/",
                HttpsAvailable = false
            },
            new LinkInfo
            {
                Reference = "R3003",
                Name = "GoldPlay UK",
                Uri = "//www.Eadent.com/",
                HttpsAvailable = false
            },
            new LinkInfo
            {
                Reference = "R3004",
                Name = "MuseGaming",
                Uri = "//www.Eadent.com/",
                HttpsAvailable = false
            },
            new LinkInfo
            {
                Reference = "R3005",
                Name = "Eadent",
                Uri = "//www.Eadent.com/",
                HttpsAvailable = false
            },
            new LinkInfo
            {
                Reference = "R3006",
                Name = "MMI Research",
                Uri = "//www.Cobham.com/",
                HttpsAvailable = true
            },
            new LinkInfo
            {
                Reference = "R3007",
                Name = "Axxia",
                //  6-Jun-2010: Redirects to: http://www.lexisnexis.org.uk/practiceandproductivitymanagement/
                // 16-Nov-2016: Redirects to: http://www.lexisnexis-es.co.uk/
                Uri = "//www.Axxia.com/",
                HttpsAvailable = false
            },
            new LinkInfo
            {
                Reference = "R3008",
                Name = "CheckFree",
                //  6-Jun-2010: Redirects to: http://www.checkfree.fiserv.com/index.html
                // 16-Nov-2016: Redirects to: https://www.fiserv.com/index.aspx
                //  3-Sep-2018: www.CheckFree.com no longer appears to redirect.
                Uri = "//www.fiserv.com/",
                HttpsAvailable = true
            },
            new LinkInfo
            {
                Reference = "R3009",
                Name = "Payzone",
                Uri = "//www.Payzone.ie/",
                HttpsAvailable = true
            },
            new LinkInfo
            {
                Reference = "R4000",
                Name = "Rapture Web Site",
                Uri = "//www.Rapture.global/",
                HttpsAvailable = true
            },
        };

        // Model Properties.
        public LinkInfo[] LinkInfoList { get; set; }

        public IActionResult OnGet(string reference)
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

            if (actionResult == null)
            {
                LinkInfoList = _linkInfoList;

                actionResult = Page();
            }

            return actionResult;
        }
    }
}
