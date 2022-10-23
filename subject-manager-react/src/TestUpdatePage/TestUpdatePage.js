import React, { useState } from "react";
import "./TestUpdatePage.css";



import { useNavigate, useParams } from "react-router";
import Button from 'react-bootstrap/Button';
import 'bootstrap/dist/css/bootstrap.css';
import axios from "axios";
import { useEffect } from "react";


function TestUpdatePage(props) {
    const { sid, tid } = useParams();
    const navigate = useNavigate();
    const [test, setTest] = useState(false);


    const handleUpdateTest = async (e) => {
        navigate(`/subjects/${sid}/view`);
        const updatedTest = {
            name: e.target.name.value,
            date: e.target.date.value,
            description: e.target.description.value
        }

        try {
            const res = await axios.put(`https://localhost:7158/api/subjects/${sid}/tests/${tid}`, updatedTest, {
                headers: {
                    'Authorization': localStorage.getItem("token")
                }
            });
        } catch (e) {
            alert(e);
        }


    }

    const getOneTest = async () => {

        try {
            const res = await axios.get(`https://localhost:7158/api/subjects/${sid}/tests/${tid}`,
                {
                    headers: {
                        'Authorization': localStorage.getItem("token")
                    }
                });
            return res.data;
        } catch (e) {
            alert(e);
        }

    }

    useEffect(() => {
        async function getOne() {

            const one = await getOneTest();
            setTest(one);
        }
        getOne()

    }, []);

    if (!test) return <div>Loading...</div>;

    return (

        <div className="add-page">
            <form action="#" onSubmit={handleUpdateTest}>
                <div className="add-inputs">
                    <input type="text" name="name" placeholder="Name" maxLength={50} required defaultValue={test.name} />
                    <input type="date" name="date" placeholder="Date" required />
                    <div>
                        <textarea id="test-desc" name="description" placeholder="Description" defaultValue={test.description}></textarea>
                    </div>
                    <div className="add-buttons">
                        <Button id="subject-add-button" variant="primary" type="submit" size="lg">Update</Button>
                        <Button id="subject-add-button" variant="dark" size="lg" onClick={() => { navigate(`/subjects/${sid}/view`) }}>Back</Button>
                    </div>
                </div>
            </form>


        </div>
    );
}

export default TestUpdatePage;