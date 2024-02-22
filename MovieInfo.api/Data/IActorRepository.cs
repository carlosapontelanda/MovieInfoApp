﻿namespace MovieInfo.api.Data;
public interface IActorRepository
{
    Task<List<Actor>> GetAllAsync(string name);
    Task<Actor> GetById(int id);
}
