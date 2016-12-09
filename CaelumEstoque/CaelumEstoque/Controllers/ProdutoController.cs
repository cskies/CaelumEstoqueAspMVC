using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaelumEstoque.DAO;
using CaelumEstoque.Models;
using System.Collections;

namespace CaelumEstoque.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            ProdutosDAO dao = new ProdutosDAO();
            IList<Produto> produtos = dao.Lista();

            //ViewBag (dynamic) manda qlq variavel pra view tier
            ViewBag.Produtos = produtos;

            return View();
        }

        public ActionResult Form()
        {
            //manda pra view a lista de categorias
            var categoriasDao = new CategoriasDAO();
            IList<CategoriaDoProduto> categorias = categoriasDao.Lista();
            ViewBag.Categorias = categorias;

            return View();
        }

        //os campos a receber da view form, sao passados como args
        [HttpPost]
        public ActionResult Adiciona(Produto produto)
        {
            //gravando no bd
            var dao = new ProdutosDAO();
            dao.Adiciona(produto);

            //modelbinder cria o obj para aspnetmvc

            return RedirectToAction("Index"); //se for contr diferente, eh soh passar como arg
        }
    }
}