import { useState } from 'react';

const BASE_URL_USERSEARCH = 'https://localhost:7055/api/UserSearch';
const BASE_URL_USER = 'https://localhost:7055/api/User';

interface FoundUser {
    id: number;
    firstName: string;
    lastName: string;
}

interface UserDetail {
    id: number;
    firstName: string;
    lastName: string;
    telephone: string;
    jobRole: string;
    email: string;
}

function SearchForm() {
    const [foundUsers, setFoundUsers] = useState<FoundUser[]>([]);
    const [selectedUsers, setSelectedUsers] = useState<UserDetail[]>([]);
    const [searchText, setSearchText] = useState('');

    /// Searches for users based on the provided search text of 2 or more characters.
    function SearchUsers(searchText) {

        // update the search input state.
        setSearchText(searchText);

        if (searchText.length >= 2)
        {
            const fetchFoundUsers = async () => {
                const response = await fetch(`${BASE_URL_USERSEARCH}/${searchText}`);
                const foundUsers = await response.json() as FoundUser[];
                setFoundUsers(foundUsers)
            };

            fetchFoundUsers();
        }
    }

    /// Handles when a user is selected from the search results.
    function HandleUserSelected(userId) {

        // create a copy of the current selected users array, as it cannot be updated directly.
        const updatedSelectedUsers = selectedUsers.slice() as UserDetail[];

        const fetchUserDetail = async () => {
            const response = await fetch(`${BASE_URL_USER}/${userId}`);
            const userDetail = await response.json() as UserDetail;

            // add the new user to the.
            updatedSelectedUsers.push(userDetail);

            // update state.
            setSelectedUsers(updatedSelectedUsers)

        };

        fetchUserDetail();

        ResetForm();
    }

    /// Resets the search form to its initial state.
    function ResetForm() {

        // clear the search input.
        setSearchText('');

        // clear the found users.
        setFoundUsers(Array(0));
    }

    let listSelectedUsers = <></>;

    if (foundUsers.length > 0) {
        listSelectedUsers = <div id="found-users">
            {
                foundUsers.map((foundUser, i) => {
                    return <div key={i} className="found-user" onClick={e => HandleUserSelected(foundUser.id)}>{foundUser.firstName} {foundUser.lastName}</div>;
                })
            }
        </div>
    }

    return <div id="user-search-wrapper">

        <div id="#user-search-input-wrapper">
            <input id="user-search-input" placeholder="Search for a user..." onChange={e => SearchUsers(e.target.value)} value={searchText} />
            <div id="user-search-go">Go!</div>
        </div>

        { listSelectedUsers }

        <div>
            {
                selectedUsers.map((user, i) => {
                    return <div key={i} className="selected-user">
                        <div>{user.firstName} {user.lastName}</div>
                        <div>{user.jobRole}</div>
                        <div>{user.telephone}</div>
                        <div>{user.email}</div>
                    </div>;
                })
            }
        </div>

    </div>;
}

export default SearchForm;