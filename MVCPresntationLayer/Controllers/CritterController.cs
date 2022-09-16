using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MVCPresntationLayer.Models;

namespace MVCPresntationLayer.Controllers
{
    public class CritterController : Controller
    {
        private ICritterManager _critterManager;
        private IFishManager _fishManager;
        private IBugManager _bugManager;
        private ISeaCreatureManager _seaCreatureManager;
        private IUserManager _userManager;
        private static List<CritterVM> _critters;
        private int PageSize = 10;

        public CritterController(ICritterManager critterManager, IFishManager fishManager, IBugManager bugManager, ISeaCreatureManager seaCreatureManager, IUserManager userManager)
        {
            _critterManager = critterManager;
            _fishManager = fishManager;
            _bugManager = bugManager;
            _seaCreatureManager = seaCreatureManager;
            _userManager = userManager;
        }

        // GET: Critter
        public ActionResult ViewAllCritters(int page = 1)
        {            
            if (_critters == null)
            {
                _critters = _critterManager.RetrieveActive();
            }
            if(Request.IsAuthenticated)
            {
                var name = User.Identity.Name;
                DataObjects.User user = _userManager.GetUserByLoginName(name);
                _critterManager.setCritterCaughtByCurrentUser(_critters, user.VillagerID);
            }
            CritterListViewModel model = new CritterListViewModel
            {
                Critters = _critters.OrderBy(c => c.CritterId).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = _critters.Count()
                }
            };
            return View(model);
        }

        /*public ActionResult ViewFilteredCritters(bool notCaughtByUser, bool catchable)
        {
            try
            {
                if (_critters == null)
                {
                    _critters = _critterManager.RetrieveActive();
                }
                if (Request.IsAuthenticated)
                {
                    var name = User.Identity.Name;
                    DataObjects.User user = _userManager.GetUserByLoginName(name);
                    _critterManager.setCritterCaughtByCurrentUser(_critters, user.VillagerID);
                }
                if (notCaughtByUser && catchable)
                {
                    if (Request.IsAuthenticated)
                    {
                        var name = User.Identity.Name;
                        DataObjects.User user = _userManager.GetUserByLoginName(name);
                        List<CritterVM> viewCritters = _critterManager.RetrieveCatchable();
                        _critterManager.setCritterCaughtByCurrentUser(viewCritters, user.VillagerID);
                        return View("viewAllCritters", viewCritters.Where(c => !c.CaughtByCurrentUser).OrderBy(c => c.CritterId).Take(PageSize));
                    }
                }
                else if (catchable)
                {
                    return View("viewAllCritters", _critterManager.RetrieveCatchable().OrderBy(c => c.CritterId).Take(PageSize));
                }
                else if (notCaughtByUser)
                {
                    if (Request.IsAuthenticated)
                    {
                        return View("viewAllCritters", _critters.Where(c => !c.CaughtByCurrentUser).OrderBy(c => c.CritterId).Take(PageSize));
                    }
                }
            }
            catch
            { }
            return View("viewAllCritters", _critters.OrderBy(c => c.CritterId).Take(PageSize));
        }*/

        public ActionResult ViewFilteredCritters(bool notCaughtByUser, bool notInMuseum, int page = 1)
        {
            CritterListViewModel model;
            try
            {
                if (notCaughtByUser)
                {
                    if (Request.IsAuthenticated)
                    {
                        var name = User.Identity.Name;
                        DataObjects.User user = _userManager.GetUserByLoginName(name);
                        _critterManager.setCritterCaughtByCurrentUser(_critters, user.VillagerID);
                        model = new CritterListViewModel
                        {
                            Critters = _critters.Where(c => !c.CaughtByCurrentUser).OrderBy(c => c.CritterId).Skip((page - 1) * PageSize).Take(PageSize),
                            PagingInfo = new PagingInfo
                            {
                                CurrentPage = page,
                                ItemsPerPage = PageSize,
                                TotalItems = _critters.Where(c => !c.CaughtByCurrentUser).Count()                                
                            },
                            NotCaughtByUser = notCaughtByUser,
                            NotInMuseum = notInMuseum
                        };
                        return View(model);
                    }
                }
                if (notInMuseum)
                {
                    if (Request.IsAuthenticated)
                    {
                        var name = User.Identity.Name;
                        DataObjects.User user = _userManager.GetUserByLoginName(name);
                        _critterManager.setCritterCaughtByCurrentUser(_critters, user.VillagerID);                        
                    }
                    model = new CritterListViewModel
                    {
                        Critters = _critters.Where(c => !c.InMuseum).OrderBy(c => c.CritterId).Skip((page - 1) * PageSize).Take(PageSize),
                        PagingInfo = new PagingInfo
                        {
                            CurrentPage = page,
                            ItemsPerPage = PageSize,
                            TotalItems = _critters.Where(c => !c.InMuseum).Count()
                        },
                        NotCaughtByUser = notCaughtByUser,
                        NotInMuseum = notInMuseum
                    };
                    return View(model);
                }
            }
            catch
            { }
            model = new CritterListViewModel
            {
                Critters = _critters.OrderBy(c => c.CritterId).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = _critters.Count()
                },
                NotCaughtByUser = notCaughtByUser,
                NotInMuseum = notInMuseum
            };
            return View(model);
        }

        public ActionResult viewCritterDetails(String critterTypeID, String critterID)
        {
            try
            {
                if (critterTypeID.Equals("fish") || critterTypeID.Equals("Fish"))
                {
                    FishVM fish = _fishManager.RetrieveFishByCritterID(critterID);
                    if (User.Identity.IsAuthenticated)
                    {
                        var user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
                        int villagerID = (user.VillagerID == null ? -1 : (int)user.VillagerID);
                        List<CritterVM> fishes = new List<CritterVM>() { fish };
                        _critterManager.setCritterCaughtByCurrentUser(fishes, villagerID);
                    }
                    return View("FishDetails", fish);
                }
                else if (critterTypeID.Equals("bug") || critterTypeID.Equals("Bug"))
                {
                    BugVM bug = _bugManager.RetrieveBugByCritterID(critterID);
                    if (User.Identity.IsAuthenticated)
                    {
                        var user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
                        int villagerID = (user.VillagerID == null ? -1 : (int)user.VillagerID);
                        List<CritterVM> bugs = new List<CritterVM>() { bug };
                        _critterManager.setCritterCaughtByCurrentUser(bugs, villagerID);
                    }
                    return View("BugDetails", bug);
                }
                else
                {
                    SeaCreature seaCreature = _seaCreatureManager.RetrieveSeaCreatureByCritterID(critterID);
                    if (User.Identity.IsAuthenticated)
                    {
                        var user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
                        int villagerID = (user.VillagerID == null ? -1 : (int)user.VillagerID);
                        List<CritterVM> seaCreatures = new List<CritterVM>() { seaCreature };
                        _critterManager.setCritterCaughtByCurrentUser(seaCreatures, villagerID);
                    }
                    return View("SeaCreatureDetails", seaCreature);
                }
            }
            catch (Exception ex)
            {
                CritterListViewModel model = new CritterListViewModel
                {
                    Critters = _critters.OrderBy(c => c.CritterId).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = 1,
                        ItemsPerPage = PageSize,
                        TotalItems = _critters.Count()
                    }
                };
                return View(model);
            }
        }

        [Authorize]
        public ActionResult Catch(string critterID)
        {
            try
            {
                var user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
                int villagerID = (user.VillagerID == null ? -1 : (int)user.VillagerID);

                _critterManager.AddCaughtBy(villagerID, critterID, DateTime.Today);
                _critters.Where(c => c.CritterId.Equals(critterID)).FirstOrDefault().CaughtByCurrentUser = true;
            }
            catch (Exception ex)
            {                
            }
            if (Request.IsAuthenticated)
            {
                var name = User.Identity.Name;
                DataObjects.User user = _userManager.GetUserByLoginName(name);
                _critterManager.setCritterCaughtByCurrentUser(_critters, user.VillagerID);
                _critters.Where(c => c.CritterId.Equals(critterID)).FirstOrDefault().CaughtByCurrentUser = true;
            }
            CritterListViewModel model = new CritterListViewModel
            {
                Critters = _critters.OrderBy(c => c.CritterId).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = 1,
                    ItemsPerPage = PageSize,
                    TotalItems = _critters.Count()
                }
            };
            return View("ViewAllCritters", model);
        }

        [Authorize]
        public ActionResult Museumify(string critterID)
        {
            try
            {
                var user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
                string loginName = (user.UserName == null ? "" : user.UserName);

                _critterManager.putCritterInMuseum(critterID, loginName);
                _critters.Where(c => c.CritterId.Equals(critterID)).FirstOrDefault().InMuseum = true;
                _critters.Where(c => c.CritterId.Equals(critterID)).FirstOrDefault().MuseumBy = loginName;
            }
            catch (Exception ex)
            {
                var name = User.Identity.Name;
                DataObjects.User user = _userManager.GetUserByLoginName(name);
                _critterManager.setCritterCaughtByCurrentUser(_critters, user.VillagerID);
            }
            CritterListViewModel model = new CritterListViewModel
            {
                Critters = _critters.OrderBy(c => c.CritterId).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = 1,
                    ItemsPerPage = PageSize,
                    TotalItems = _critters.Where(c => c.InMuseum).Count()
                }
            };
            return View("ViewAllCritters", model);
        }

        [Authorize(Roles = "Museum Admin")]
        public ActionResult Unmuseumify(string critterID)
        {
            try
            {
                _critterManager.removeCritterFromMuseum(critterID);
                _critters.Where(c => c.CritterId.Equals(critterID)).FirstOrDefault().InMuseum = false;
                _critters.Where(c => c.CritterId.Equals(critterID)).FirstOrDefault().MuseumBy = "";
            }
            catch (Exception ex)
            {
                var name = User.Identity.Name;
                DataObjects.User user = _userManager.GetUserByLoginName(name);
                _critterManager.setCritterCaughtByCurrentUser(_critters, user.VillagerID);
            }
            CritterListViewModel model = new CritterListViewModel
            {
                Critters = _critters.Where(c => c.InMuseum).OrderBy(c => c.CritterId).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = 1,
                    ItemsPerPage = PageSize,
                    TotalItems = _critters.Where(c => c.InMuseum).Count()
                }
            };
            return View("ViewMuseum", model);
        }

        [Authorize]
        public ActionResult ViewUserCritters(int page = 1)
        {
            
            try
            {
                var user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
                int villagerID = (user.VillagerID == null ? -1 : (int)user.VillagerID);
                List<CritterVM> viewCritters = _critterManager.RetrieveCaughtByUser(villagerID);
                _critterManager.setCritterCaughtByCurrentUser(viewCritters, villagerID);
                CritterListViewModel model = new CritterListViewModel
                {
                    Critters = viewCritters.OrderBy(c => c.CritterId).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = viewCritters.Count()
                    }
                };
                return View(model);
            }
            catch
            {
                if (_critters == null)
                {
                    _critters = _critterManager.RetrieveActive();
                }
                if (Request.IsAuthenticated)
                {
                    var name = User.Identity.Name;
                    DataObjects.User user = _userManager.GetUserByLoginName(name);
                    _critterManager.setCritterCaughtByCurrentUser(_critters, user.VillagerID);
                }
                CritterListViewModel model = new CritterListViewModel
                {
                    Critters = _critters.OrderBy(c => c.CritterId).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = _critters.Count()
                    }
                };
                return View("ViewAllCritters", model);
            }
        }

        public ActionResult ViewMuseum(int page = 1)
        {
            if (_critters == null)
            {
                _critters = _critterManager.RetrieveActive();
            }
            if (Request.IsAuthenticated)
            {
                var name = User.Identity.Name;
                DataObjects.User user = _userManager.GetUserByLoginName(name);
                _critterManager.setCritterCaughtByCurrentUser(_critters, user.VillagerID);
            }
            CritterListViewModel model = new CritterListViewModel
            {
                Critters = _critters.Where(c => c.InMuseum).OrderBy(c => c.CritterId).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = _critters.Where(c => c.InMuseum).Count()
                }
            };
            return View(model);
        }
    }
}