﻿using System;
using IRB.Revigo.Core.Databases;

namespace GenerateSpeciesAnnotations
{
	/// <summary>
	/// Utility that generates Species Annotations for the REVIGO
	/// 
	/// Authors:
	/// 	Rajko Horvat (https://github.com/rajko-horvat)
	/// 
	/// License:
	/// 	MIT
	/// 	Copyright (c) 2011-2023, Ruđer Bošković Institute
	///		
	/// 	Permission is hereby granted, free of charge, to any person obtaining a copy of this software 
	/// 	and associated documentation files (the "Software"), to deal in the Software without restriction, 
	/// 	including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
	/// 	and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, 
	/// 	subject to the following conditions: 
	/// 	The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
	/// 	The names of authors and contributors may not be used to endorse or promote Software products derived from this software 
	/// 	without specific prior written permission.
	/// 	
	/// 	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
	/// 	INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
	/// 	FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. 
	/// 	IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, 
	/// 	DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, 
	/// 	ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
	/// </summary>
	class Program
	{
		static void Main(string[] args)
		{
			// which organisms to process
			int[] aTaxonIDs = new int[] {
				0,	// whole UniProt (default)
				3055,	// Chlamydomonas reinhardtii
				3702,	// Arabidopsis thaliana
				3827,	// Cicer arietinum
				4081,	// Solanum lycopersicum
				4577,	// Zea mays
				6239,	// Caenorhabditis elegans
				7227,	// Drosophila melanogaster
				7955,	// Danio rerio
				8364,	// Xenopus tropicalis
				9031,	// Gallus gallus
				9606,	// Homo sapiens
				9913,	// Bos taurus
				10090,	// Mus musculus
				10116,	// Rattus norvegicus
				13249,	// Rhodnius prolixus
				31033,	// Takifugu rubripes
				36329,	// Plasmodium falciparum
				39947,	// Oryza sativa
				44689,	// Dictyostelium discoideum
				83332,	// Mycobacterium tuberculosis
				83333,	// Escherichia coli
				208964,	// Pseudomonas aeruginosa
				224308,	// Bacillus subtilis
				284812,	// Schizosaccharomyces pombe
				559292,	// Saccharomyces cerevisiae
				946362, // Salpingoeca rosetta
				1111708	// Synechocystis sp.
			};
			// (*1) These organisms were added ...

			// serialize Gene Ontology
			GeneOntology oOntology = new GeneOntology(@"Z:\GeneOntology\2023_05_10\go.obo");
			oOntology.Serialize(@"C:\Revigo\Databases\New\GeneOntology.xml.gz");

			SpeciesAnnotationList annotations = SpeciesAnnotationList.FromGOA(
				@"Z:\EBI_GOA\2023_03_15\goa_uniprot_gcrp.gaf",
				@"Z:\GeneOntology\2023_05_10\go.obo",
				@"Z:\Taxonomy_NCBI\2023_05_22\names.dmp",
				aTaxonIDs);

			// serialize Annotation object
			annotations.Serialize(@"C:\Revigo\Databases\New\SpeciesAnnotations.xml.gz");

			Console.WriteLine("Finished, press Enter key");
			Console.ReadLine();
		}
	}
}
