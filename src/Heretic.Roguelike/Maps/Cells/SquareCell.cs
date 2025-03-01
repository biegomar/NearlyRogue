﻿using System.Collections.Generic;
using System.Linq;
using Heretic.Roguelike.Numerics;
using Heretic.Roguelike.Things;


namespace Heretic.Roguelike.Maps.Cells;

public class SquareCell<T> : ISquareCell<T>, IHexCell<T>
{
    private readonly IDictionary<Directions, ICell<T>?> neighbours = new Dictionary<Directions, ICell<T>?>();
    private readonly IList<ICell<T>> linkedCells = new List<ICell<T>>();

    public int X { get; init; }
    public int Y { get; init; }
    public int Z { get; init; }
    public IThing<T>? Item { get; set; }

    public bool IsVisible { get; set; }

    public int PathCount { get; set; }

    public bool IsVisited { get; set; }

    public ICell<T>? Predecessor { get; set; }

    public ICell<T>? NorthernNeighbour
    {
        get => neighbours[Directions.North];
        set => neighbours[Directions.North] = value;
    }

    public ICell<T>? EasternNeighbour
    {
        get => neighbours[Directions.East];
        set => neighbours[Directions.East] = value;
    }

    public ICell<T>? SouthernNeighbour
    {
        get => neighbours[Directions.South];
        set => neighbours[Directions.South] = value;
    }

    public ICell<T>? WesternNeighbour
    {
        get => neighbours[Directions.West];
        set => neighbours[Directions.West] = value;
    }

    public ICell<T>? NorthernEastNeighbour
    {
        get => neighbours[Directions.Northeast];
        set => neighbours[Directions.Northeast] = value;
    }

    public ICell<T>? SouthernWestNeighbour
    {
        get => neighbours[Directions.Southwest];
        set => neighbours[Directions.Southwest] = value;
    }

    public ICell<T>? SouthernEastNeighbour
    {
        get => neighbours[Directions.Southeast];
        set => neighbours[Directions.Southeast] = value;
    }

    public ICell<T>? NorthernWestNeighbour
    {
        get => neighbours[Directions.Northwest];
        set => neighbours[Directions.Northwest] = value;
    }

    public IList<ICell<T>> LinkedCells => this.linkedCells;

    public IDictionary<Directions, ICell<T>?> Neighbours => this.neighbours;

    public void LinkCell(SquareCell<T> cellToLink)
    {
        if (!this.LinkedCells.Contains(cellToLink))
        {
            this.LinkedCells.Add(cellToLink);
            cellToLink.LinkCell(this);
        }
    }
}