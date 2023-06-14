import { useEffect, useState } from 'react';
import { ContactItem } from  '../components';
import { getContactsFilterd } from "../helpers";
import { useSearchParams } from 'react-router-dom';

export const ContactList = () => {      
  
  const [ searchParams, setSearchParams ] = useSearchParams();

  const contactSearch = searchParams.get('search');
  
  const [contactsSearchResult, setContactsSearchResult] = useState([]);

  useEffect(() => {    
    const fetchContacts = () => {
      getContactsFilterd(contactSearch).then((response) => {
        setContactsSearchResult(response);
      });
    };

    fetchContacts();

  }, [contactSearch]);
  
  return (    
    <>
      <div className='list-group overflow-auto shadow list-group-menu'>

      {
        contactsSearchResult.map(contact => (        

          <ContactItem key={contact.id} {...contact} queryParameter={contactSearch} />
        ))
      }
      </div>
    </>
  )
}
