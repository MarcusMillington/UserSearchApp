import { useState } from "react";

const BASE_URL_USER = 'https://localhost:7055/api/User';

function CreateUserForm() {

    const [showForm, setShowForm] = useState(false);
    const [hasErrors, setHasErrors] = useState(false);
    const [firstName, setFirstName] = useState("");
    const [lastName, setLastName] = useState("");
    const [telephone, setTelephone] = useState("");
    const [jobRole, setJobRole] = useState("");
    const [email, setEmail] = useState("");
    const [hasAddedNewUser, setHasAddedNewUser] = useState(false);

    const handleSubmit = (event) => {
        event.preventDefault();

        setHasErrors(false);

        if (firstName.length == 0) {
            setHasErrors(true);
        }

        if (lastName.length == 0) {
            setHasErrors(true);
        }

        if (telephone.length == 0) {
            setHasErrors(true);
        }

        if (jobRole.length == 0) {
            setHasErrors(true);
        }

        if (email.length == 0) {
            setHasErrors(true);
        }

        if (!hasErrors) {
            fetch(`${BASE_URL_USER}`, {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    "firstName": firstName,
                    "lastName": lastName,
                    "telephone": telephone,
                    "jobRole": jobRole,
                    "email": email
                })
            })

            setFirstName('')
            setLastName('')
            setTelephone('')
            setJobRole('')
            setEmail('')
            setHasAddedNewUser(true)
        }
    };

    function handleToggleCreateUserForm() {
        if (showForm) {
            setShowForm(false);
        }
        else {
            setShowForm(true);
        }
    }

    let createUserForm;
    
    if (showForm) {

        let errorMessage;

        if (hasErrors) {
            errorMessage = <span className="create-user-form-error-message">Please enter values for all the fields</span>;
        }

        createUserForm =
        <form id="create-user-form" onSubmit={handleSubmit}>
            <div className="create-user-form-row">
                <input className="create-user-form-first-name" type="text" name="firstName" placeholder="First name" value={firstName} onChange={(e) => setFirstName(e.target.value)} />
                <input className="create-user-form-last-name" type="text" name="lastName" placeholder="Last name" value={lastName} onChange={(e) => setLastName(e.target.value)} />
            </div>
            <div className="create-user-form-row">
                <input className="create-user-form-job-title" type="text" name="telephone" placeholder="Job title" value={telephone} onChange={(e) => setTelephone(e.target.value)} />
                <input className="create-user-form-phone" type="text" name="jobRole" placeholder="Phone" value={jobRole} onChange={(e) => setJobRole(e.target.value)} />
                <input className="create-user-form-email" type="email" name="email" placeholder="Email" value={email} onChange={(e) => setEmail(e.target.value)} />
            </div>

            {errorMessage}

            {/* ... potentially many more individual input fields */}
            <div id="create-user-button-wrapper">
                <button id="create-user-button" type="submit">Create</button>
            </div>
        </form>
    }

    let newUserMessage;

    if (hasAddedNewUser) {
        newUserMessage = <div id="create-user-form-new-user-added">
            <span>New User Added!</span>
            <button onClick={(e) => setHasAddedNewUser(false) }>x</button>
        </div>
    }

    return (
        <>
            {newUserMessage}
            {createUserForm}
            <div id="toggle-create-user-button-wrapper">
                <button id="toggle-create-user-button" onClick={ handleToggleCreateUserForm }>New User +</button>
            </div>
        </>
    );
}

export default CreateUserForm;