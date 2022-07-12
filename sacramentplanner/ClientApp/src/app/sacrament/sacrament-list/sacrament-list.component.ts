import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { Sacrament } from '../sacrament.model';
import { SacramentService } from '../sacrament.service';

@Component({
  selector: 'app-sacrament-list',
  templateUrl: './sacrament-list.component.html',
  styleUrls: ['./sacrament-list.component.css'],
})
export class SacramentListComponent implements OnInit {
  sacraments: Sacrament[] = [];
  // subscription: Subscription;
  constructor(private sacramentService: SacramentService) {}

  ngOnInit() {
    this.sacramentService.getSacraments();
    // this.subscription =
    this.sacramentService.sacramentListChangedEvent.subscribe(
      (sacraments: Sacrament[]) => {
        this.sacraments = sacraments;
        // console.log(this.sacraments);
      }
    );
  }

  // ngOnDestroy(): void {
  //   this.subscription.unsubscribe();
  // }
}
