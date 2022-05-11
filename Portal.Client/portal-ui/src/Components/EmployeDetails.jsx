import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import PortalApi from "../Api/PortalApi";
import profileImg from "../img/user.png"
import ProcessData from './ProcessData';

export default function EmployeDetails() {
    let { id } = useParams();
    const [data, setData] = useState([]);
    useEffect(() => {
        const fetchPosts = async () => {
            const response = await PortalApi.getEmployeById(id);
            setData(response.data);
        };
        fetchPosts();
    }, []);

    return (
        <div class="card">
            <div class="container-fliud">
                <div class="wrapper row">
                    <div class="preview col-md-3">
                        <div class="preview-pic tab-content">
                            <div class="tab-pane active" id="pic-1"><img className='profile-img' src={profileImg} /></div>
                        </div>
                    </div>
                    <div class="details col-md-9">
                        <h3 className="title-color"> Employee Details</h3>
                        <table class="table table-borderless">
                            
                            <tbody>
                                <tr>
                                    <td className='col-width'>Name</td>
                                    <td>{data.firstName} {data.lastName}</td>
                                </tr>
                                <tr>
                                    <td>Phone</td>
                                    <td>{data.phone}</td>
                                </tr>
                                <tr>
                                    <td>Email</td>
                                    <td>{data.email}</td>
                                </tr>
                                <tr>
                                    <td>Education</td>
                                    <td>{data.education}</td>
                                </tr>
                                <tr>
                                    <td>Gender</td>
                                    <td>{data.gender}</td>
                                </tr>
                            </tbody>
                        </table>
                        <ProcessData key={data.id} data={data} />
                    </div>
                </div>
            </div>
        </div >
    );
}
