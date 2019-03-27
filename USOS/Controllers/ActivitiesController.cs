using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USOS.Models.Activities;
using USOSData.Interfaces;

namespace USOS.Controllers
{
    public class ActivitiesController : Controller
    {
        private IUsosActivity _activities;

        public ActivitiesController(IUsosActivity activity)
        {
            _activities = activity;
        }

        public IActionResult Index()
        {
            var activityModels = _activities.GetAll();
            var listingResult = activityModels
                .Select(result => new ActivityIndexListingModel
                {
                    Id = result.Id,
                    Group = _activities.GetGroup(result.Id),
                    Type = _activities.GetType(result.Id),
                    Subject = _activities.GetSubject(result.Id)
                });
            var model = new ActivityIndexModel
            {
                Activities = listingResult
            };
            return View(model);
        }
    }
}
