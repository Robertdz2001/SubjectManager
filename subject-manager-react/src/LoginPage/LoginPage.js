import React from "react";
import "./LoginPage.css";
import axios from "axios";
import {
    BrowserRouter as Router,
    Routes,
    Route,
    Navigate,
} from "react-router-dom";
import { useState } from "react";
import { useNavigate } from "react-router-dom";

function LoginPage() {
    const navigate = useNavigate();

    const handleLogin = async (e) => {
        const user = {
            email: e.target.email.value,
            password: e.target.password.value
        }
        e.preventDefault()
        try {
            const res = await axios.post('https://localhost:7158/api/user/login', user);

            localStorage.setItem("token", "Bearer " + res.data);
            navigate("/home");

        } catch (e) {
            alert('Invalid email or password');
        }

    }


    return (
        <div className="login-page">
            <div className="inputs glass-bg">
                <div className="login-title demoFont" >Login</div>
                <form onSubmit={handleLogin}>

                    <div className="email-input">
                        <input id="email" type="email" name="email" placeholder="Email" />
                    </div>

                    <div className="password-input">
                        <input id="password" type="password" name="password" placeholder="Password" />
                    </div>
                    <input id="login-button" type="submit" value="Login" />
                </form >

                <div className="link-to-register"><a href="/register" >Don't have an account? Click here.</a></div>
            </div>
        </div >


    );




}
export default LoginPage;