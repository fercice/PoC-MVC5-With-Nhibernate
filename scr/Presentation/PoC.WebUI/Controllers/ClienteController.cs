using System;
using System.Collections.Generic;
using AutoMapper;
using System.Web.Mvc;
using PoC.Domain.Business;
using PoC.Domain.Entities;
using PoC.Domain.Messages;
using PoC.Services.Interface;
using PoC.WebUI.ViewModel;

namespace PoC.WebUI.Controllers
{
    public class ClienteController : BaseController
    {
        private readonly IClienteService _clienteService;
        private readonly ICompraService _compraService;
        private readonly IProdutoService _produtoService;

        public ClienteController(IClienteService clienteService, ICompraService compraService, IProdutoService produtoService)
        {
            _clienteService = clienteService;
            _compraService = compraService;
            _produtoService = produtoService;
        }

        public ActionResult Index()
        {
            var clientes = Mapper.Map<IList<Cliente>, IList<ClienteViewModel>>(_clienteService.GetAll());

            return View(clientes);
        }

        public ActionResult Salvar()
        {
            var clientes = Mapper.Map<IList<Cliente>, IList<ClienteViewModel>>(_clienteService.GetAll());

            return View("Index", clientes);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Salvar(ClienteViewModel cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clienteService.InsertOrUpdate(Mapper.Map<ClienteViewModel, Cliente>(cliente));
                    ViewBag.ReturnMessageOk = Messaging.MessageSavedOk;
                }

                var clientes = Mapper.Map<IList<Cliente>, IList<ClienteViewModel>>(_clienteService.GetAll());

                return View("Index", clientes);
            }
            catch (Exception ex)
            {                
                ViewBag.ReturnMessageError = Messaging.MessageSavedError + ": " + ex.Message;

                return View("Index");
            }
        }

        public ActionResult Produtos(int idCliente)
        {
            var cliente = Mapper.Map<Cliente, ClienteViewModel>(_clienteService.GetById(idCliente));
            var compra = Mapper.Map<IList<Compra>, IList<CompraViewModel>>(_compraService.BuscarCompraPorCliente(idCliente));
            var produtos = Mapper.Map<IList<Produto>, IList<ProdutoViewModel>>(_produtoService.GetAll());
            
            ViewData["Cliente"] = cliente;
            ViewData["ListaProdutos"] = produtos;

            return View(compra);
        }

        public ActionResult AdicionarProduto(int idCliente, int idProduto)
        {
            var cliente = Mapper.Map<Cliente, ClienteViewModel>(_clienteService.GetById(idCliente));
            var compra = Mapper.Map<IList<Compra>, IList<CompraViewModel>>(_compraService.BuscarCompraPorCliente(idCliente));
            var compraAssociada = Mapper.Map<Compra, CompraViewModel>(_compraService.BuscarCompraPorClienteEProduto(idCliente, idProduto));
            var produto = Mapper.Map<Produto, ProdutoViewModel>(_produtoService.GetById(idProduto));
            var produtos = Mapper.Map<IList<Produto>, IList<ProdutoViewModel>>(_produtoService.GetAll());

            ViewData["Cliente"] = cliente;
            ViewData["ListaProdutos"] = produtos;

            if (compra.Count == Rules.LimiteDeProdutosPorCliente)
            {
                ViewBag.CompraReturnMessageError = Messaging.MessageClienteProdutoAdicionadoLimite;
                return View("Produtos", compra);
            }
            
            if (compraAssociada != null)
            {
                ViewBag.CompraReturnMessageError = Messaging.MessageClienteProdutoAdicionado;
                return View("Produtos", compra);
            }

            try
            {
                CompraViewModel viewModel = new CompraViewModel
                {
                    Cliente = cliente,
                    Produto = produto
                };
                _compraService.InsertOrUpdate(Mapper.Map<CompraViewModel, Compra>(viewModel));

                ViewBag.CompraReturnMessageOk = Messaging.MessageClienteAddProdutoSavedOk;                

                return View("Produtos", compra);
            }
            catch (Exception ex)
            {
                ViewBag.CompraReturnMessageError = Messaging.MessageSavedError;
                return View("Produtos", compra);
            }            
        }

        public ActionResult RemoverProduto(int idCliente, int idProduto)
        {
            var cliente = Mapper.Map<Cliente, ClienteViewModel>(_clienteService.GetById(idCliente));
            var compra = Mapper.Map<IList<Compra>, IList<CompraViewModel>>(_compraService.BuscarCompraPorCliente(idCliente));            
            var produtos = Mapper.Map<IList<Produto>, IList<ProdutoViewModel>>(_produtoService.GetAll());

            ViewData["Cliente"] = cliente;
            ViewData["ListaProdutos"] = produtos;            

            try
            {
                var compraAssociada = Mapper.Map<Compra, CompraViewModel>(_compraService.BuscarCompraPorClienteEProduto(idCliente, idProduto));

                _compraService.Delete(compraAssociada.Id);

                ViewBag.CompraReturnMessageOk = Messaging.MessageClienteProdutoRemovido;

                return View("Produtos", compra);
            }
            catch (Exception ex)
            {
                ViewBag.CompraReturnMessageError = Messaging.MessageSavedError;
                return View("Produtos", compra);
            }
        }

    }
}