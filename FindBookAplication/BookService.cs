﻿using FindBookDomain.Aplication;
using FindBookDomain.Dto;
using FindBookDomain.Model;
using FindBookDomain.Repository;
using System.Collections.Generic;
using System.Linq;

namespace FindBookAplication {
    public class BookService : IBookService {
        private readonly IBookRepository _repo;

        public BookService(IBookRepository repo)
        {
            _repo = repo;
        }

        public List<Book> BuscarLivros(FiltrosDTO filtros)
        {
            var livros = _repo.Query();

            if (!string.IsNullOrEmpty(filtros.Autor))
                livros = livros.Where(p => p.Specifications.Author.Contains(filtros.Autor)).ToList();

            if (!string.IsNullOrEmpty(filtros.NomeLivro))
                livros = livros.Where(p => p.Name.Contains(filtros.NomeLivro)).ToList();

            if (filtros.PrecoInicial != null)
                livros = livros.Where(p => p.Price >= filtros.PrecoInicial).ToList();

            if (filtros.PrecoFinal != null)
                livros = livros.Where(p => p.Price <= filtros.PrecoFinal).ToList();

            if (!string.IsNullOrEmpty(filtros.Genero))
                livros = livros.Where(p => p.Specifications.Genres.Contains(filtros.Genero)).ToList();

            if (!string.IsNullOrEmpty(filtros.Ilustrador))
                livros = livros.Where(p => p.Specifications.Illustrator.Contains(filtros.Ilustrador)).ToList();

            if (filtros.QuantidadePaginasInicial != null)
                livros = livros.Where(p => p.Specifications.PageCount >= filtros.QuantidadePaginasInicial).ToList();

            if (filtros.QuantidadePaginasFinal != null)
                livros = livros.Where(p => p.Specifications.PageCount <= filtros.QuantidadePaginasFinal).ToList();

            return livros;
        }
    }
}
