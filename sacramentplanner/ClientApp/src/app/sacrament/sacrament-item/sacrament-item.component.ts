import { Component, Input, OnInit } from '@angular/core';
import { Sacrament } from '../sacrament.model';

@Component({
  selector: 'app-sacrament-item',
  templateUrl: './sacrament-item.component.html',
  styleUrls: ['./sacrament-item.component.css'],
})
export class SacramentItemComponent implements OnInit {
  @Input() sacrament: Sacrament;
  constructor() {}

  ngOnInit(): void {}
}
