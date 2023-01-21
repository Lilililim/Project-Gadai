import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/models/users.model';
import { UsersService } from 'src/app/services/users.service';
import * as moment from 'moment';
import { UserSearch } from 'src/app/models/userSearch.model';
@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.css'],
})
export class UsersListComponent implements OnInit {
  users: User[] = [];
  search: User[] = [];
  searchId: string = '';
  searchName: string = '';
  searchKeterangan: string = '';
  searchHp: string = '';
  // searchArg: UserSearch = {
  //   searchId: '',
  //   searchName: '',
  //   searchKet: '',
  //   searchHp: '',
  // };

  constructor(private usersService: UsersService) {}

  ngOnInit(): void {
    this.usersService.doGetAllEmployees().subscribe({
      next: (users) => {
        this.users = users;
      },
      error: (response) => {
        console.log(response);
      },
    });
  }

  doSearchUser() {
    // const searchQueries = [this.searchId, this.searchName, this.searchKeterangan, this.searchHp]
    const params = new URLSearchParams({
      searchId: this.searchId,
      searchName: this.searchName,
      searchKet: this.searchKeterangan,
      searchHp: this.searchHp,
    });
    this.usersService.doSearchUser('search', params).subscribe({
      next: (hasil) => {
        console.log(hasil);
        this.search = hasil;
      },
    });
  }

  clearInput() {
    this.searchId = '';
    this.searchName = '';
    this.searchKeterangan = '';
    this.searchHp = '';
  }
}
