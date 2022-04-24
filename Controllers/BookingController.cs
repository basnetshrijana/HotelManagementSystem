using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HotelManagementSystem.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _db;
        public BookingController(ApplicationDbContext db)
        {
            _db=db;
        }
        public IActionResult Index()
        {
            var objCategoryList=_db.Bookings.ToList();
             return View(objCategoryList);
        }

         //Get
         public IActionResult Create()
        {
            
             return View();
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Booking obj)
        {

            if(ModelState.IsValid){
            
            _db.Bookings.Add(obj);
            
            _db.SaveChanges();
            TempData["success"]="Booking created successfully";
             return RedirectToAction("Index");
            }
            return View(obj);
        }
         //Get
         public IActionResult Edit(int? id)
        {
            if(id==null ||id==0){
                return NotFound();
            }
            var bookingFromDb=_db.Bookings.FirstOrDefault(x =>x.BookingId == id);
            if(bookingFromDb==null)
            {
                return View(bookingFromDb);
            }
             return View(bookingFromDb);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Booking obj)
        {

            if(ModelState.IsValid){
            
            _db.Bookings.Update(obj);
            
            _db.SaveChanges();
            TempData["success"]="Booking updated successfully";
             return RedirectToAction("Index");
            }
            return View(obj);
        }
           




         //Get
          
         public IActionResult Delete(int? id)
        {
            if(id==null ||id==0){
                return NotFound();
            }
            var bookingFromDb=_db.Bookings.Find(id);
            if(bookingFromDb==null)
            {
                return View(bookingFromDb);
            }
             return View(bookingFromDb);
        }
        //Post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj= _db.Bookings.Find(id);
            if(obj==null)
            {
                return NotFound();
            }
            _db.Bookings.Remove(obj);
            _db.SaveChanges();
             TempData["success"]="Booking deleted successfully";
            return RedirectToAction("Index");
            

        
        }
        
        
       
    }


}
        