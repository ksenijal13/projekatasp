using Application;
using Application.Commands;
using Application.DataTransfer;
using AutoMapper;
using Domain;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Commands
{
    public class EfCreateOrderCommand : ICreateOrderCommand
    {
        private PerfumeContext _context;
        private readonly IMapper _mapper;
        private IApplicationActor _actor;
        public EfCreateOrderCommand(PerfumeContext context, IMapper mapper, IApplicationActor actor)
        {
            _context = context;
            _mapper = mapper;
            _actor = actor;
        }
        public int Id => 16;

        public string Name => "Creating order";

        public void Execute(OrderDto request)
        {
            int userId = _actor.Id;
            request.Address = _context.Users.Find(userId).Address;
            request.UserId = userId;
            foreach(OrderItemDto item in request.OrderItems)
            {
                item.Price = item.Quantity * _context.Perfumes.Find(item.PerfumeId).Price;
                var perfumeCart = _context.Carts.Where(x => (x.PerfumeId == item.PerfumeId) && (x.UserId == userId)).FirstOrDefault();
                if(perfumeCart is Cart)
                {
                    perfumeCart.IsDeleted = true;
                    perfumeCart.DeletedAt = DateTime.Now;
                    perfumeCart.IsActive = false;
               }
                var perfume = _context.Perfumes.Find(item.PerfumeId);
                perfume.NumberOfAvailable = perfume.NumberOfAvailable - item.Quantity;
            }

            var order = _mapper.Map<Order>(request);
             
            _context.Add(order);
            _context.SaveChanges();
        }
    }
}
