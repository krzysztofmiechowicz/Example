using MOK.Interfaces;
using MOK.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using AutoMapper;

namespace MOK.Controllers
{
    public class OrderController : Controller
    {
        private readonly ILoggerService loggerService;
        private readonly IOrderService orderService;
        private readonly IOfferService offerService;



        public OrderController(
            IOrderService orderService,
            ILoggerService loggerService,
            IOfferService offerService)
        {
            this.orderService = orderService;
            this.loggerService = loggerService;
            this.offerService = offerService;
        }
        public ActionResult Index()
        {

            var model  = new OrdersViewModel()
            {
                    Orders = Mapper.Map<List<OrderViewModel>>(orderService.GetOrders()),
                    Offers = offerService.GetOfferItems()
            };

            return View(model);
        }

        // GET: Order/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            var order = orderService.GetOrderDetails(id);
            var model = new OrderDetailsViewModel()
            {
                Items = Mapper.Map<List<OrderDetailDTO>>(order)
            };
            return new JsonResult() { Data = model , JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            var model = offerService.GetOfferItems();
            return View(model);
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(List<OrderItemInputModel> order)
        {

            try
            {
                orderService.AddOrder(order);
                //return RedirectToRoute(Url.Action("Index","Order"));
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch(Exception ex)
            {
                loggerService.Log(ex.Message);
                return View();
            }
        }
    }
}
