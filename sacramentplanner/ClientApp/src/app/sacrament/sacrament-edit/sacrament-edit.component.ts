import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Sacrament } from '../sacrament.model';
import { SacramentService } from '../sacrament.service';

@Component({
  selector: 'app-sacrament-edit',
  templateUrl: './sacrament-edit.component.html',
  styleUrls: ['./sacrament-edit.component.css'],
})
export class SacramentEditComponent implements OnInit {
  originalSacrament: Sacrament;
  sacrament: Sacrament;
  editMode: boolean = false;
  talks: any;
  today = new Date();

  constructor(
    private sacramentService: SacramentService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    // this.route.data.subscribe((data: { sacrament: Sacrament }) => {
    //   this.originalSacrament = data.sacrament;
    //   this.sacrament = JSON.parse(JSON.stringify(this.originalSacrament));
    // });
  }

  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      const id = params['id'];
      if (id == null) {
        this.editMode = false;
        return;
      }
      this.originalSacrament = this.sacramentService.getSacrament(id);
      if (this.originalSacrament == null) {
        return;
      }
      this.editMode = true;
      this.sacrament = JSON.parse(JSON.stringify(this.originalSacrament));
      for (const prop in this.sacrament) {
        if (prop === 'talks') {
          this.talks = this.sacrament[prop];
        }
      }
    });
  }

  onSubmit(form: NgForm) {
    const value = form.value;
    const newSacrament = new Sacrament(
      0,
      value.sacramentDate,
      value.presiding,
      value.conducting,
      +value.openingHymnNumber,
      value.openingHymnName,
      value.invocation,
      value.sacramentHymnName,
      +value.sacramentHymnNumber,
      value.talks,
      value.isFastSunday,
      value.closingHymnName,
      +value.closingHymnNumber,
      value.benediction
    );
    if (this.editMode) {
      this.sacramentService.updateSacrament(
        this.originalSacrament,
        newSacrament
      );
    } else {
      console.log(newSacrament);
      this.sacramentService.addSacrament(newSacrament);
    }
    this.router.navigate(['/sacrament']);
  }

  onCancel() {
    this.router.navigate(['/sacrament']);
  }
}
