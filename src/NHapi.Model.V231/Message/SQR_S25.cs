using System;
using System.Collections.Generic;
using NHapi.Base.Log;
using NHapi.Model.V231.Group;
using NHapi.Model.V231.Segment;
using NHapi.Model.V231.Datatype;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;

namespace NHapi.Model.V231.Message

{
///<summary>
/// Represents a SQR_S25 message structure (see chapter [AAA]). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (MSH - message header segment) </li>
///<li>1: MSA (MSA - message acknowledgment segment) </li>
///<li>2: ERR (ERR - error segment) optional </li>
///<li>3: QAK (Query Acknowledgement) </li>
///<li>4: SQR_S25_SCHEDULE (a Group object) optional repeating</li>
///<li>5: DSC (DSC - Continuation pointer segment) optional </li>
///</ol>
///</summary>
[Serializable]
public class SQR_S25 : AbstractMessage  {

	///<summary> 
	/// Creates a new SQR_S25 Group with custom IModelClassFactory.
	///</summary>
	public SQR_S25(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new SQR_S25 Group with DefaultModelClassFactory. 
	///</summary> 
	public SQR_S25() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for SQR_S25.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(MSA), true, false);
	      this.add(typeof(ERR), false, false);
	      this.add(typeof(QAK), true, false);
	      this.add(typeof(SQR_S25_SCHEDULE), false, true);
	      this.add(typeof(DSC), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating SQR_S25 - this is probably a bug in the source code generator.", e);
	   }
	}


	public override string Version
		{
			get{
			return Constants.VERSION;
			}
		}
	///<summary>
	/// Returns MSH (MSH - message header segment) - creates it if necessary
	///</summary>
	public MSH MSH { 
get{
	   MSH ret = null;
	   try {
	      ret = (MSH)this.GetStructure("MSH");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns MSA (MSA - message acknowledgment segment) - creates it if necessary
	///</summary>
	public MSA MSA { 
get{
	   MSA ret = null;
	   try {
	      ret = (MSA)this.GetStructure("MSA");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns ERR (ERR - error segment) - creates it if necessary
	///</summary>
	public ERR ERR { 
get{
	   ERR ret = null;
	   try {
	      ret = (ERR)this.GetStructure("ERR");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns QAK (Query Acknowledgement) - creates it if necessary
	///</summary>
	public QAK QAK { 
get{
	   QAK ret = null;
	   try {
	      ret = (QAK)this.GetStructure("QAK");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of SQR_S25_SCHEDULE (a Group object) - creates it if necessary
	///</summary>
	public SQR_S25_SCHEDULE GetSCHEDULE() {
	   SQR_S25_SCHEDULE ret = null;
	   try {
	      ret = (SQR_S25_SCHEDULE)this.GetStructure("SCHEDULE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of SQR_S25_SCHEDULE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public SQR_S25_SCHEDULE GetSCHEDULE(int rep) { 
	   return (SQR_S25_SCHEDULE)this.GetStructure("SCHEDULE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of SQR_S25_SCHEDULE 
	 */ 
	public int SCHEDULERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("SCHEDULE").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the SQR_S25_SCHEDULE results 
	 */ 
	public IEnumerable<SQR_S25_SCHEDULE> SCHEDULEs 
	{ 
		get
		{
			for (int rep = 0; rep < SCHEDULERepetitionsUsed; rep++)
			{
				yield return (SQR_S25_SCHEDULE)this.GetStructure("SCHEDULE", rep);
			}
		}
	}

	///<summary>
	///Adds a new SQR_S25_SCHEDULE
	///</summary>
	public SQR_S25_SCHEDULE AddSCHEDULE()
	{
		return this.AddStructure("SCHEDULE") as SQR_S25_SCHEDULE;
	}

	///<summary>
	///Removes the given SQR_S25_SCHEDULE
	///</summary>
	public void RemoveSCHEDULE(SQR_S25_SCHEDULE toRemove)
	{
		this.RemoveStructure("SCHEDULE", toRemove);
	}

	///<summary>
	///Removes the SQR_S25_SCHEDULE at the given index
	///</summary>
	public void RemoveSCHEDULEAt(int index)
	{
		this.RemoveRepetition("SCHEDULE", index);
	}

	///<summary>
	/// Returns DSC (DSC - Continuation pointer segment) - creates it if necessary
	///</summary>
	public DSC DSC { 
get{
	   DSC ret = null;
	   try {
	      ret = (DSC)this.GetStructure("DSC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
