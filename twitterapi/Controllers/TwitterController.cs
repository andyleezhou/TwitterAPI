using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using twitterapi.Models;

namespace twitterapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwitterController : ControllerBase
    {
        private readonly TwitterContext _context;

        public TwitterController(TwitterContext context)
        {
            _context = context;
        }

        // GET: api/Twitter
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Twitter>>> GetTwitterTweets()
        {
            return await _context.TwitterTweets.ToListAsync();
        }

        // GET: api/Twitter/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Twitter>> GetTwitter(long id)
        {
            var twitter = await _context.TwitterTweets.FindAsync(id);

            if (twitter == null)
            {
                return NotFound();
            }

            return twitter;
        }

        // PUT: api/Twitter/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTwitter(long id, Twitter twitter)
        {
            if (id != twitter.Id)
            {
                return BadRequest();
            }
            const int MaxLength = 10;

            if (twitter.Content.Length > MaxLength) {
                return BadRequest();
            }

            _context.Entry(twitter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TwitterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Twitter
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Twitter>> PostTwitter(Twitter twitter)
        {
            _context.TwitterTweets.Add(twitter);
            Console.WriteLine(twitter);
         

            const int MaxLength = 240;

            if (twitter.Content.Length > MaxLength)
            {
                return BadRequest();
            }
            else
            {
                _context.TwitterTweets.Add(twitter);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetTwitter", new { id = twitter.Id }, twitter);
            }

        }

        // DELETE: api/Twitter/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Twitter>> DeleteTwitter(long id)
        {
            var twitter = await _context.TwitterTweets.FindAsync(id);
            if (twitter == null)
            {
                return NotFound();
            }

            _context.TwitterTweets.Remove(twitter);
            await _context.SaveChangesAsync();

            return twitter;
        }

        private bool TwitterExists(long id)
        {
            return _context.TwitterTweets.Any(e => e.Id == id);
        }
    }
}
