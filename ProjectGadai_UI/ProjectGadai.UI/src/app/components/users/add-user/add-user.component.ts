import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import * as moment from 'moment';
import { User } from 'src/app/models/users.model';
import { UsersService } from 'src/app/services/users.service';
@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {

  addUserRequest: User = {
    user_id: '',
    nama_user: '',
    nomor_hp: '',
    keterangan: '',
    maks_transaksi: 0,
    tanggal_masuk: moment().toDate()
  }
  constructor(private usersService: UsersService, private router: Router){}

  ngOnInit(): void {

  }

  addUser(){
    this.usersService.doInsert(this.addUserRequest)
    .subscribe({
      next: (user) => {
        this.router.navigate(['users']);
      }
    });
  }
}
