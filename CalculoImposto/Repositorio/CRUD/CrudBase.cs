﻿using CalculoImposto.API.Banco;
using CalculoImposto.API.Repositorio.CRUD.Interface;
using Microsoft.EntityFrameworkCore;

namespace CalculoImposto.API.Repositorio.CRUD;

public class CrudBase<T> : ICrudBase<T> where T : class
{
    private readonly CalculoImpostoContext _calculoImpostoContext;
    private readonly DbSet<T> _dbSet;

    public CrudBase(CalculoImpostoContext calculoImpostoContext)
    {
        _calculoImpostoContext = calculoImpostoContext;
        _dbSet = _calculoImpostoContext.Set<T>();
    }
    public async Task<T> Atualizar(T entity)
    {
        _dbSet.Attach(entity);


        _calculoImpostoContext.Entry(entity).State = EntityState.Modified;
        await _calculoImpostoContext.SaveChangesAsync();
        return entity;


    }

    public async Task<T> Criar(T entity)
    {
        await _dbSet.AddAsync(entity);
        _calculoImpostoContext.Add(entity);
        await _calculoImpostoContext.SaveChangesAsync();
        return entity;



    }

    public async Task<T> Deletar(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity != null)
        {

            _calculoImpostoContext.Remove(entity);
            await _calculoImpostoContext.SaveChangesAsync();
            return entity;
        }
        return entity;

    }

    public async Task<T> PegarPorId(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        return entity;
    }

    public async Task<IEnumerable<T>> PegarTodos(int pagina, int tamanho, string busca)
    {
        try
        {
            var inssList = await _dbSet.ToListAsync();

            return inssList;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
