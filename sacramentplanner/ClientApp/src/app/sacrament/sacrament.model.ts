export class Sacrament {
  constructor(
    public sacramentPlanId: number,
    public sacramentDate: Date,
    public presiding: string,
    public conducting: string,
    public openingHymnNumber: number,
    public openingHymnName: string,
    public invocation: string,
    public sacramentHymnName: string,
    public sacramentHymnNumber: number,
    public talks: any[],
    public isFastSunday: boolean,
    public closingHymnName: string,
    public closingHymnNumber: number,
    public benediction: string
  ) {}
}
