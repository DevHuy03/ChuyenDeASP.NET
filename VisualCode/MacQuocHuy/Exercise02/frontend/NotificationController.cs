using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Exercise02.Models;
using Exercise02.Context;

namespace Exercise02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public NotificationsController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/Notifications
        [HttpGet]
        public IActionResult GetNotifications()
        {
            var notifications = _context.Notifications.ToList();
            return Ok(notifications);
        }

        // GET: api/Notifications/{id}
        [HttpGet("{id}")]
        public IActionResult GetNotification(Guid id)
        {
            var notification = _context.Notifications.FirstOrDefault(n => n.Id == id);
            if (notification == null)
            {
                return NotFound();
            }
            return Ok(notification);
        }

        // POST: api/Notifications
        [HttpPost]
        public IActionResult CreateNotification([FromBody] Notification notification)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Notifications.Add(notification);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetNotification), new { id = notification.Id }, notification);
        }

        // PUT: api/Notifications/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateNotification(Guid id, [FromBody] Notification notification)
        {
            if (id != notification.Id)
            {
                return BadRequest();
            }

            _context.Entry(notification).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Notifications/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(Guid id)
        {
            var notification = _context.Notifications.Find(id);
            if (notification == null)
            {
                return NotFound();
            }

            _context.Notifications.Remove(notification);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
