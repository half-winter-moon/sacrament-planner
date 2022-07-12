import { Injectable } from '@angular/core';
import { Sacrament } from './sacrament.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SacramentService {
  sacramentListChangedEvent = new Subject<Sacrament[]>();

  sacraments: Sacrament[] = [];

  constructor(private http: HttpClient) {}

  // sortAndSend() {
  //   this.sacraments.sort((a, b) =>
  //     a.name > b.name ? 1 : b.name > a.name ? -1 : 0
  //   );
  //   this.sacramentListChangedEvent.next(this.sacraments.slice());
  // }

  getSacrament(id: number) {
    // console.log(this.sacraments);
    // return this.sacraments.find(
    //   (sacrament) => sacrament.sacramentPlanId === id
    // );
    for (let doc of this.sacraments) {
      if (doc.sacramentPlanId == id) {
        return doc;
      }
    }

    return null;
  }

  getSacraments() {
    this.http
      .get<Sacrament[]>('https://localhost:7095/api/sacrament')
      .subscribe(
        (sacramentData) => {
          this.sacraments = sacramentData;
          // this.maxSacramentId = this.getMaxId();
          // this.sacraments.sort((a, b) =>
          //   a.name > b.name ? 1 : a.name < b.name ? -1 : 0
          // );
          this.sacramentListChangedEvent.next(this.sacraments.slice());
        },
        (error) => {
          console.log(error);
        }
      );
  }

  // deleteSacrament(sacrament: Sacrament) {
  //   if (!sacrament) {
  //     return;
  //   }

  //   const pos = this.sacraments.findIndex(
  //     (d) => d.SacramentPlanId === sacrament.SacramentPlanId
  //   );

  //   if (pos < 0) {
  //     return;
  //   }

  //   // delete from database
  //   this.http
  //     .delete('http://localhost:3000/sacraments/' + sacrament.SacramentPlanId)
  //     .subscribe((response: Response) => {
  //       this.sacraments.splice(pos, 1);
  //       // this.sortAndSend();
  //     });
  // }

  // addSacrament(sacrament: Sacrament) {
  //   if (!sacrament) {
  //     return;
  //   }

  //   // make sure id of the new Sacrament is empty
  //   sacrament.SacramentPlanId = '';

  //   const headers = new HttpHeaders({ 'Content-Type': 'application/json' });

  //   // add to database
  //   this.http
  //     .post<{ message: string; sacrament: Sacrament }>(
  //       'http://localhost:3000/sacraments',
  //       sacrament,
  //       { headers: headers }
  //     )
  //     .subscribe((responseData) => {
  //       // add new sacrament to sacraments
  //       this.sacraments.push(responseData.sacrament);
  //       // this.sortAndSend();
  //     });
  // }

  // updateSacrament(originalSacrament: Sacrament, newSacrament: Sacrament) {
  //   if (!originalSacrament || !newSacrament) {
  //     return;
  //   }
  //   const pos = this.sacraments.findIndex(
  //     (d) => d.SacramentPlanId === originalSacrament.SacramentPlanId
  //   );

  //   if (pos < 0) {
  //     return;
  //   }

  //   // set the id of the new Sacrament to the id of the old Sacrament
  //   newSacrament.SacramentPlanId = originalSacrament.SacramentPlanId;
  //   // newSacrament._id = originalSacrament._id; WHERE IS THIS??

  //   const headers = new HttpHeaders({ 'Content-Type': 'application/json' });

  //   // update database
  //   this.http
  //     .put(
  //       'http://localhost:3000/sacraments/' + originalSacrament.SacramentPlanId,
  //       newSacrament,
  //       { headers: headers }
  //     )
  //     .subscribe((response: Response) => {
  //       this.sacraments[pos] = newSacrament;
  //       // this.sortAndSend();
  //     });
  // }
}
