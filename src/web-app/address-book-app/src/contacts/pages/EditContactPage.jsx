import { useEffect } from 'react';
import { useNavigate, useParams, NavLink, useSearchParams } from 'react-router-dom';
import { FormProvider, useForm } from 'react-hook-form';
import { format } from 'date-fns';

import { getContactById, putContact } from '../helpers';
import { ContactForm } from '../components'

export const EditContactPage = () => {
    const methods = useForm();
    const navigate = useNavigate();

    const {id} = useParams();

    const [ searchParams ] = useSearchParams();

    const contactSearch = searchParams.get('search');

    useEffect(() => {
        const fetchContact = async() => {
            const response = await getContactById(id);
            
            if(!response)
                navigate('/contacts');
            
            methods.setValue('firstName', response.firstName);
            methods.setValue('lastName', response.lastName);
            methods.setValue('phoneNumber', response.phoneNumber);
            methods.setValue('physicalAddress', response.physicalAddress);
            methods.setValue('phoneNumber', response.phoneNumber);
            methods.setValue('email', response.email);
            methods.setValue('companyName', response.companyName);

            if(response.birthday)
                methods.setValue('birthday', format(new Date(response.birthday), 'yyyy-MM-dd'));
        };
    
        fetchContact();
    }, []);

    const onSaveSubmit = methods.handleSubmit(data => {
        event.preventDefault();
        let contact = {...data};
        if(contact.birthday === ''){
            contact.birthday = null;
        }

        putContact(id, contact).then((response) => {
            if(response){
                alert('The contact was updated');
                navigate(`/contacts/${id}?search=${contactSearch}`);
            }
        });
    });

    return (
        <>
        <div className="row">
            <div className='col-8'>
                <div className="card shadow">
                    <div className="card-body">
                        <h3 className='card-title'>Edit Contact</h3>

                        <hr/>
                        <FormProvider {...methods}>
                            <form onSubmit={onSaveSubmit} noValidate>

                                <ContactForm></ContactForm>

                                <hr/>
                        
                                <div className='mt-3'>
                                    <div className="row">
                                        <div className="col-2">
                                            <button type="submit" className="btn btn-outline-primary"            
                                                >
                                                Save
                                            </button>
                                        </div>
                                        <div className="col-2">
                                            <NavLink className="btn btn-primary"
                                                to={`/contacts/${id}?search=${contactSearch}`}>
                                                Cancel
                                            </NavLink>
                                        </div>
                                    </div>
                                </div>
                            </form>
                        </FormProvider>
                    </div>
                </div>
            </div>
        </div>
        </>
  )
}

