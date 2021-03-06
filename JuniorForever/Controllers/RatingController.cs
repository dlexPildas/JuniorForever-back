﻿using JuniorForever.Domain.Interfaces;
using JuniorForever.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace JuniorForever.Api.Controllers
{
    [Route("ratings")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingRepository ratingRepository;
        public RatingController(IRatingRepository ratingRepository)
        {
            this.ratingRepository = ratingRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Rating rating)
        {
            try
            {
                ratingRepository.Add(rating);

                await ratingRepository.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await ratingRepository.GetAllRatings();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}