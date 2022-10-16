import React from "react";
import { useNavigate } from "react-router";
import "./RegisterPage.css";
import axios from "axios";
function RegisterPage() {
    const navigate = useNavigate();

    const handleRegister = async (e) => {
        const user = {
            email: e.target.email.value,
            password: e.target.password.value,
            firstName: e.target.firstname.value,
            lastName: e.target.lastname.value,
            phoneNumber: e.target.phonenumber.value
        }
        console.log(user);
        e.preventDefault()
        try {
            const res = await axios.post('https://localhost:7158/api/user/register', user);
            if (res) {
                console.log(res);
                alert('Registered successfully.');
                navigate("/login");
            }
            else {
                throw Error(res);
            }

        } catch (e) {
            alert(e);
        }



    }
    return (
        <div className="register-page">
            <div className="inputs">
                <div className="register-title">Register</div>
                <form className="register" onSubmit={handleRegister}>
                    <div className="register-inputs">
                        <input id="email-register" type="email" name="email" placeholder="Email" />
                        <input id="password-register" type="password" name="password" placeholder="Password" />
                        <input id="firstname" type="text" name="firstname" placeholder="Firstname" />
                        <input id="lastname" type="text" name="lastname" placeholder="Lastname" />
                        <input id="phonenumber" type="tel" name="phonenumber" placeholder="PhoneNumber" pattern="[0-9]{2}[0-9]{3}[0-9]{3}[0-9]{3}" />
                        <div className="register-button"> <input id="register-button" type="submit" value="Register" /></div>
                    </div>
                </form >
            </div>
        </div >
    );

}

export default RegisterPage;