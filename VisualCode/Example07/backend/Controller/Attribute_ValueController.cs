// using Microsoft.AspNetCore.Mvc;
// using System;
// using System.Linq;
// using MacQuocHuy.Exercise02.Models;
// using MacQuocHuy.Exercise02.Context;
// using Microsoft.EntityFrameworkCore;

// namespace MacQuocHuy.Exercise02.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class Attribute_ValueController : ControllerBase
//     {
//         private readonly Exercise02Context _context;

//         public Attribute_ValueController(Exercise02Context context)
//         {
//             _context = context;
//         }

//         // GET: api/AttributeValue
//         [HttpGet]
//         public IActionResult GetAttributeValues()
//         {
//             var attributevalues = _context.Attribute_Values.ToList();
//             return Ok(attributevalues);
//         }

//         // GET: api/AttributeValue/{id}
//         [HttpGet("{id}")]
//         public IActionResult GetAttributeValue(Guid id)
//         {
//             var attributevalue = _context.Attribute_Values.Find(id);
//             if (attributevalue == null)
//             {
//                 return NotFound();
//             }
//             return Ok(attributevalue);
//         }

//    // POST: api/AttributeValues
//         [HttpPost]
//         public async Task<ActionResult<Attribute_Value>> PostAttributeValue(Attribute_Value attributeValue)
//         {
//             _context.Attribute_Values.Add(attributeValue);
//             await _context.SaveChangesAsync();

//             return CreatedAtAction("GetAttributeValue", new { id = attributeValue.id }, attributeValue);
//         }

//         // PUT: api/AttributeValues/5
//         [HttpPut("{id}")]
//         public async Task<IActionResult> PutAttributeValue(Guid id, Attribute_Value attributeValue)
//         {
//             if (id != attributeValue.id)
//             {
//                 return BadRequest();
//             }

//             _context.Entry(attributeValue).State = EntityState.Modified;

//             try
//             {
//                 await _context.SaveChangesAsync();
//             }
//             catch (DbUpdateConcurrencyException)
//             {
//                 if (!AttributeValueExists(id))
//                 {
//                     return NotFound();
//                 }
//                 else
//                 {
//                     throw;
//                 }
//             }

//             return NoContent();
//         }

//         // DELETE: api/AttributeValues/5
//         [HttpDelete("{id}")]
//         public async Task<IActionResult> DeleteAttributeValue(int id)
//         {
//             var attributeValue = await _context.Attribute_Values.FindAsync(id);
//             if (attributeValue == null)
//             {
//                 return NotFound();
//             }

//             _context.Attribute_Values.Remove(attributeValue);
//             await _context.SaveChangesAsync();

//             return NoContent();
//         }

//         private bool AttributeValueExists(Guid id)
//         {
//             return _context.Attribute_Values.Any(e => e.id == id);
//         }
//     }
// }
