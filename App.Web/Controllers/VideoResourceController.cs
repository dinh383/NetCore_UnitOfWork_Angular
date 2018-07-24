using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Data.Entities;
using App.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    public class VideoResourceController : Controller
    {
        private readonly IResource_VideoService _videoService;
        public VideoResourceController(IResource_VideoService videoService)
        {
            this._videoService = videoService;
        }
        [Route("video.html")]
        public IActionResult Home()
        {
            return View();
        }

        [Route("video-detail.html")]
        public async Task<IActionResult> VideoDetail(int id)
        {
            var video = await _videoService.GetSingleByIdAsync(id);
            if (video != null)
            {
                return View(video);
            }
            return RedirectToAction("Index","Error");
        }
        [HttpGet]
        public async Task<IActionResult> SearchVideo(string keySearch)
        {
            var videos = await _videoService.SearchVideo(keySearch);
            ViewBag.TotalVideo = videos.Count();
            return View(videos);
        }
    }
}