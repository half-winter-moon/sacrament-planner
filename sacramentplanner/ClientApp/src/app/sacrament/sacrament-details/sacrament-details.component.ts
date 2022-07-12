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
  sacrament: Sacrament;
  id: number = 1;
  nativeWindow: any;

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
      this.id = params['id'];
      // if (this.id == null) {
      //   this.id = 1;
      // }
      this.sacramentService.getSacrament(this.id);
      console.log(this.id);
    });
  }

  // onDelete() {
  //   this.sacramentService.deleteSacrament(this.sacrament);
  //   this.router.navigate(['/documents'], { relativeTo: this.route });
  // }
}
