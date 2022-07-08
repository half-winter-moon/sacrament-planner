export class Sacrament {
  constructor(
    public SacramentPlanId: number,
    public SacramentDate: Date,
    public Presiding: string,
    public Conducting: string,
    public OpeningHymn: string,
    public Invocation: string,
    public SacramentHymn: string,
    public talks: [],
    public IsFastSunday: boolean,
    public ClosingHymn: string,
    public Benediction: string
  ) {}
}
