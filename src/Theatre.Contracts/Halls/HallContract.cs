namespace Theatre.Contracts.Halls;

public record HallContract(int HallId,string Name, int SeatsNum, int GridSchemeColumnsCount,int GridSchemeRowsCount);