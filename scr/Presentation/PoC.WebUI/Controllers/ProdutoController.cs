using System;
using System.Collections.Generic;
using AutoMapper;
using System.Web.Mvc;
using PoC.Domain.Entities;
using PoC.Domain.Messages;
using PoC.Services.Interface;
using PoC.WebUI.ViewModel;

namespace PoC.WebUI.Controllers
{
    public class ProdutoController : BaseController
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        public ActionResult Index()
        {
            var produtos = Mapper.Map<IList<Produto>, IList<ProdutoViewModel>>(_produtoService.GetAll());

            return View(produtos);
        }

        public ActionResult Salvar()
        {
            var produtos = Mapper.Map<IList<Produto>, IList<ProdutoViewModel>>(_produtoService.GetAll());

            return View("Index", produtos);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Salvar(ProdutoViewModel produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _produtoService.InsertOrUpdate(Mapper.Map<ProdutoViewModel, Produto>(produto));
                    ViewBag.ReturnMessageOk = Messaging.MessageSavedOk;
                }

                var produtos = Mapper.Map<IList<Produto>, IList<ProdutoViewModel>>(_produtoService.GetAll());

                return View("Index", produtos);
            }
            catch (Exception ex)
            {
                ViewBag.ReturnMessageError = Messaging.MessageSavedError + ": " + ex.Message;

                return View("Index");
            }
        }
    }
}