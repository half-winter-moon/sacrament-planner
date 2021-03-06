import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Sacrament } from '../sacrament.model';
import { SacramentService } from '../sacrament.service';
import { WindRefService } from 'src/app/wind-ref.service';

@Component({
  selector: 'app-sacrament-details',
  templateUrl: './sacrament-details.component.html',
  styleUrls: ['./sacrament-details.component.css'],
})
export class SacramentDetailsComponent implements OnInit {
  sacramentDetail: Sacrament;
  id: number = 1;
  nativeWindow: any;
  talks: any;

  constructor(
    private sacramentService: SacramentService,
    private route: ActivatedRoute,
    private router: Router,
    private windRefService: WindRefService
  ) {
    this.nativeWindow = windRefService.getNativeWindow();
  }

  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      this.id = +params['id'];
      // if (this.id == null) {
      //   this.id = 1;
      // }
      this.sacramentDetail = this.sacramentService.getSacrament(this.id);
      for (const prop in this.sacramentDetail) {
        if (prop === 'talks') {
          this.talks = this.sacramentDetail[prop];
        }
      }
      // console.log(this.talks);
    });
  }

  onDelete() {
    this.sacramentService.deleteSacrament(this.sacramentDetail);
    this.router.navigate(['/sacrament'], { relativeTo: this.route });
  }
}
