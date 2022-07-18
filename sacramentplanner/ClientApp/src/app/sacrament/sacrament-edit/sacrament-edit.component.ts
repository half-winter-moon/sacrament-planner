import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, NgForm } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Sacrament } from '../sacrament.model';
import { SacramentService } from '../sacrament.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
@Component({
  selector: 'app-sacrament-edit',
  templateUrl: './sacrament-edit.component.html',
  styleUrls: ['./sacrament-edit.component.css'],
})
export class SacramentEditComponent implements OnInit {
  originalSacrament: Sacrament;
  sacraments:Sacrament[];
  sacrament: Sacrament;
  editMode: boolean = false;
  talks: any[] = [];
  today = new Date();
  sacramentForm: FormGroup;
  isAdd:boolean= false;

  constructor(
    private sacramentService: SacramentService,
    private router: Router,
    private route: ActivatedRoute,
    private http: HttpClient
  ) {
    // this.route.data.subscribe((data: { sacrament: Sacrament }) => {
    //   this.originalSacrament = data.sacrament;
    //   this.sacrament = JSON.parse(JSON.stringify(this.originalSacrament));
    // });
  }

  ngOnInit() {
    this.sacramentService.sacramentListChangedEvent.subscribe(
      (sacraments: Sacrament[]) => {
        this.sacraments = sacraments;
        console.log(this.sacraments);
        if(this.isAdd)
        {
          console.log("herrererer")
          this.isAdd= false;
          var lastItem = this.sacraments[this.sacraments.length-1];
          console.log(lastItem);
          console.log(this.talks);
           this.sacramentForm.value.talks.forEach((element2, index)=>{
             var speakers='';
             var topics='';
            if (index % 2 == 0){
              speakers = element2
              topics = this.sacramentForm.value.talks[index+1]

              var data = {
              Speaker : speakers,
              Topic: topics,
              SacramentPlanId: lastItem.sacramentPlanId
            }

            const headers = new HttpHeaders({ 'Content-Type': 'application/json' });

    // add to database
            this.http
              .post<Sacrament>('https://localhost:7095/api/talk', data, {
                headers: headers,
              })
              .subscribe((responseData) => {
                // add new sacrament to sacraments
              this.sacramentForm.value.talk = responseData;
              const value = this.sacramentForm.value;
              const newSacrament2 = new Sacrament(
                  0,
                  value.sacramentDate,
                  value.presiding,
                  value.conducting,
                  +value.openingHymnNumber,
                  value.openingHymnName,
                  value.invocation,
                  value.sacramentHymnName,
                  +value.sacramentHymnNumber,
                  this.sacramentForm.value.talk,
                  value.isFastSunday,
                  value.closingHymnName,
                  +value.closingHymnNumber,
                  value.benediction
                );
               this.sacramentService.updateSacrament(
              this.originalSacrament,
              newSacrament2
            );




              });




            // fetch('http://localhost:7095/api/talk', {
            // method: 'POST', // or 'PUT'
            // headers: {
            //   'Content-Type': 'application/json',
            // },
            // body: JSON.stringify(data),
            // })
            // .then(response => response.json())
            // .then(data => {
            // console.log('Success:', data);
            // })
            // .catch((error) => {
            // console.error('Error:', error);
            // });
          }
        })
      }

      })
    this.route.params.subscribe((params: Params) => {
      const id = params['id'];
      this.sacramentForm = new FormGroup({
        sacramentDate: new FormControl(null),
        presiding: new FormControl(null),
        conducting: new FormControl(null),
        openingHymnNumber: new FormControl(null),
        openingHymnName: new FormControl(null),
        invocation: new FormControl(null),
        sacramentHymnName: new FormControl(null),
        sacramentHymnNumber: new FormControl(null),
        talks: new FormArray([]),
        closingHymnName: new FormControl(null),
        closingHymnNumber: new FormControl(null),
        benediction: new FormControl(null),
        });
        

      
      if (id == null) {
        this.editMode = false;
        console.log("here in create")        
        return;
      }

      this.originalSacrament = this.sacramentService.getSacrament(id);
      console.log(this.originalSacrament)
      
      if (this.originalSacrament == null) {
        return;
      }
      
      this.editMode = true;
      this.sacrament = JSON.parse(JSON.stringify(this.originalSacrament));
      
    });


    console.log(this.sacrament);
    //edit
    if(this.editMode){
      console.log(this.sacrament.talks)
      console.log("edit mode")
          this.sacramentForm.setValue({
            sacramentDate: this.sacrament.sacramentDate,
            presiding: this.sacrament.presiding,
            conducting: this.sacrament.conducting,
            openingHymnNumber: this.sacrament.openingHymnNumber,
            openingHymnName: this.sacrament.openingHymnName,
            invocation: this.sacrament.invocation,
            sacramentHymnName: this.sacrament.sacramentHymnName,
            sacramentHymnNumber: this.sacrament.sacramentHymnNumber,
            talks:[],
            closingHymnName: this.sacrament.closingHymnName,
            closingHymnNumber: this.sacrament.closingHymnNumber,
            benediction: this.sacrament.benediction,
          })
      
         this.sacrament.talks.forEach((element, index, array) => {
            const control = new FormControl(element.speaker);
            (<FormArray>this.sacramentForm.get("talks")).push(control);
            const control2 = new FormControl(element.topic);
            (<FormArray>this.sacramentForm.get("talks")).push(control2);
        });
        }
   
  }
getControls() {
  return (<FormArray>this.sacramentForm.get('talks')).controls;
}
onSubmit() {
    const value = this.sacramentForm.value;
    console.log(this.sacramentForm.value)

    if (this.editMode) {
    this.sacrament.talks.forEach((element, index, array) => {
    this.sacramentForm.value.talks.forEach((element2, index)=>{
        if (index % 2 == 0){
          element.speaker = element2;
        }
        else{
          element.topic = element2
        }
      })
    
            
    });
    console.log(this.sacrament.talks)
      const newSacrament2 = new Sacrament(
      0,
      value.sacramentDate,
      value.presiding,
      value.conducting,
      +value.openingHymnNumber,
      value.openingHymnName,
      value.invocation,
      value.sacramentHymnName,
      +value.sacramentHymnNumber,
      this.sacrament.talks,
      value.isFastSunday,
      value.closingHymnName,
      +value.closingHymnNumber,
      value.benediction
    );
      this.sacramentService.updateSacrament(
        this.originalSacrament,
        newSacrament2
      );
    } else {

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
      null,
      value.isFastSunday,
      value.closingHymnName,
      +value.closingHymnNumber,
      value.benediction
    );
      console.log(newSacrament);
      this.sacramentService.addSacrament(newSacrament);
      this.talks = this.sacramentForm.value.talks
     this.isAdd = true;
    }
    this.router.navigate(['/sacrament']);
  }

  onAddTalk() {
    const speaker = new FormControl(null);
  
    const topic = new FormControl(null);
    (<FormArray>this.sacramentForm.get('talks')).push(topic);
     const topic2 = new FormControl(null);
    (<FormArray>this.sacramentForm.get('talks')).push(topic2);
  }

  
  onCancel() {
    this.router.navigate(['/sacrament']);
  }
}
