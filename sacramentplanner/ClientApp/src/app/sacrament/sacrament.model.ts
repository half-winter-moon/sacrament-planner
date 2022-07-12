export class Sacrament {
  constructor(
    public sacramentPlanId: number,
    public sacramentDate: Date,
    public presiding: string,
    public conducting: string,
    public openingHymn: string,
    public invocation: string,
    public sacramentHymn: string,
    public talks: [],
    public isFastSunday: boolean,
    public closingHymn: string,
    public benediction: string
  ) {}
}
