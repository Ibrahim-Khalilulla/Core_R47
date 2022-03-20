using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_R47.VC
{
    public class SocialLinksViewComponent : ViewComponent
    {
        List<SocialIcon> socialIcons = new List<SocialIcon>();
        public SocialLinksViewComponent()
        {
            socialIcons = SocialIcon.AppSocialIcons();//5 records
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = socialIcons;
            return await Task.FromResult((IViewComponentResult)View("SocialLinks", model));
        }
    }

}
